using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour {

    public int xSpeed = 5;
    public int ySpeed = 5;
    private Vector3 mouse;
    public string xaxis = "P1X";
    public string yaxis = "P1Y";
    public string rxAxis = "P1SX";
    public string ryAxis = "P1SY";

    // Around 200-250 good range for this
    public float shotStrength = 200;

    public BoxCollider2D boxCollider;
    
    private Vector2 movement;
    public bool facingRight;
    public GameObject ball = null;
    public bool hasPossession;
    public float multiplier = 50;

    public BallScript ballScript;

    public float frictionCoefficent = 0.8f;

    //public Vector3 worldPos;
   // public Vector3 ballPos;
    //public Vector3 shoot;
    
	// Use this for initialization
	void Start () {
        if (!facingRight) {
            Flip(0);
        }
    }
	
	// Update is called once per frame
	void Update ()
    {
        mouse = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 15));

        // Get input from joysticks
        float inX = Input.GetAxis(xaxis);
        float inY = Input.GetAxis(yaxis);

        print("Input: " + inX + ", " + inY);

        // Flip the character to face direction of movement
        if (inX < 0 && facingRight) {
            Flip(1);
        }
        else if(inX > 0 && !facingRight) {
            Flip(1);
        }

        movement = new Vector2(
            xSpeed * inX,
            ySpeed * inY    
        );
  
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
    public bool getDirection()
    {
            return facingRight;
    }

    void FixedUpdate() {
        GetComponent<Rigidbody2D>().AddForce(.5f * movement);
        if (movement.x == 0 && movement.y == 0 && GetComponent<Rigidbody2D>().velocity != Vector2.zero) {
            Vector2 friction = GetComponent<Rigidbody2D>().velocity * -1;
            GetComponent<Rigidbody2D>().AddForce(friction * frictionCoefficent);
        }
    }

    /// <summary>
    /// Change direction character is facing
    /// If you are using for during game, pass a 1 to the function
    /// If you are using for setup, pass a 0 to the function
    /// </summary>
    void Flip(int type) {
        // Change direction facing
        if(type == 1) {
            facingRight = !facingRight;
        }

        // Flip the scale of the Character
        Vector3 charScale = transform.localScale;
        charScale.x *= -1;
        transform.localScale = charScale;
    }

    /// <summary>
    /// Get the box collider associated with this player
    /// </summary>
    /// <returns></returns>
    public BoxCollider2D getBoxCollider() {
        return boxCollider;
    }

    void OnCollisionEnter2D(Collider2D coll) {
        if(coll.gameObject.tag == "goal") {
            movement = movement * 1.2f;
        }
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        //broom interactions
        if(coll.gameObject.tag == "ball")
        {
            hasPossession = true;
            ball = coll.gameObject;
            ballScript = ball.GetComponent<BallScript>();
        }
    }

    /// <summary>
    /// Needed so you cannot shot the ball outside of the stick trigger
    /// </summary>
    /// <param name="coll">2D Collider attached to player characters</param>
    void OnTriggerExit2D(Collider2D coll) {
        if(coll.gameObject.tag == "ball") {
            hasPossession = false;
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

        // Get Direction of Right Joystick
        float dirX = Input.GetAxis(rxAxis);
        float dirY = Input.GetAxis(ryAxis);

        // Create vector in direction of right jostick
        Vector2 direction = new Vector2(dirX, dirY);

        // multiplier needed for believable shot
        direction *= (shotStrength * 50);

        // Let go of ball
        hasPossession = false;
        ballScript.setFollow(false);

        // Add force to ball
        ball.GetComponent<Rigidbody2D>().AddForce(direction);

        ball = null;
       
    }
}
