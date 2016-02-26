using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour {

    public int xSpeed = 5;
    public int ySpeed = 5;

    public string xaxis = "P1X";
    public string yaxis = "P1Y";

    private Vector2 movement;
    public bool facingRight;
    public GameObject ball;
    public bool hasPossession;
    public float x;
    public float y;
    public Vector2 read;
	// Use this for initialization
	void Start () {
    }
	
	// Update is called once per frame
	void Update ()
    {
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
        if (Input.GetMouseButtonDown(0) && hasPossession)
        {
            Shoot(ball);
        }

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

    void Shoot(GameObject ball)
    {
        
        Vector2 shoot = (Input.mousePosition - ball.GetComponent<Transform>().position);
        ball.GetComponent<Rigidbody2D>().AddForce(shoot);
        hasPossession = false;
        ball = null;
    }
}
