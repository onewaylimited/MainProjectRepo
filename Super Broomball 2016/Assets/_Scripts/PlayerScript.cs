using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour {

    public int xSpeed = 5;
    public int ySpeed = 5;
    public Vector3 mouse;
    public string xaxis = "P1X";
    public string yaxis = "P1Y";

    // Around 200-250 good range for this
    public float shotStrength = 200;
    
    private Vector2 movement;
    private Vector2 lastDirection;
    public bool facingRight;
    public GameObject ball = null;
    public bool hasPossession;
    public float multiplier = 50; 
    //public Vector3 worldPos;
   // public Vector3 ballPos;
    //public Vector3 shoot;
    
	// Use this for initialization
	void Start () {
    }
	
	// Update is called once per frame
	void Update ()
    {
        mouse = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 15));
        float inX = Input.GetAxis(xaxis);
        float inY = Input.GetAxis(yaxis);
       
        // Flip the character to face direction of movement
        if(inX < 0 && facingRight) {
            Flip();
        }
        else if(inX > 0 && !facingRight) {
            Flip();
        }

        movement = new Vector2(
            xSpeed * inX,
            ySpeed * inY    
        );

        //Keep track of last direction (for joysticks)
        if(inX != 0 || inY != 0) {
            lastDirection.x = inX;
            lastDirection.y = inY;
        }
  

        // Mouse Support
        if (Input.GetMouseButtonDown(0) && hasPossession)
        {
            Shoot(ball);
        }

        // JoyStick Support
        if (Input.GetButtonDown("Shoot") && hasPossession) {
            JoystickShoot(ball);
        }
        //worldPos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 15));
        //ballPos = ball.GetComponent<Transform>().position;
       // shoot = worldPos - ballPos;
    }
    public bool getBool()
    {
            return facingRight;
    }
    void FixedUpdate()
    {
        GetComponent<Rigidbody2D>().velocity = movement;
    }

    /// <summary>
    /// Change direction character is facing
    /// </summary>
    void Flip() {
        // Change direction facing
        facingRight = !facingRight;

        // Flip the scale of the Character
        Vector3 charScale = transform.localScale;
        charScale.x *= -1;
        transform.localScale = charScale;
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        //broom interactions
        if(coll.gameObject.tag == "ball")
        {
            hasPossession = true;
            ball = coll.gameObject; 
        }
    }

    /// <summary>
    /// Needed so you cannot shot the ball outside of the stick trigger
    /// </summary>
    /// <param name="coll">2D Collider attached to player characters</param>
    void OnTriggerExit2D(Collider2D coll) {
        if(coll.gameObject.tag == "ball") {
            hasPossession = false;
            ball = null;
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="ball"></param>
    void Shoot(GameObject ball)
    {
        Vector3 worldPos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 15));
        Vector3 ballPos = ball.GetComponent<Transform>().position;
        Vector3 shoot = multiplier*(worldPos - ballPos);
        //shoot = (worldPos - ball.GetComponent<Transform>().position);
        ball.GetComponent<Rigidbody2D>().AddForce(shoot);
        hasPossession = false;
        ball = null;
    }

    /// <summary>
    /// Shooting function for controllers
    /// </summary>
    /// <param name="ball"></param>
    void JoystickShoot(GameObject ball) {
        Vector2 shotForce = lastDirection;

        // x50 multiplier needed for believable shot
        shotForce *= (shotStrength * 50);

        ball.GetComponent<Rigidbody2D>().AddForce(shotForce);

        print("Shot Taken!");
    }
}
