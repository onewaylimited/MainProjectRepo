using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour {

    private Vector2 speed = new Vector2(5, 5);
    private Vector2 movement;
    private bool facingRight;

	// Use this for initialization
	void Start () {
        facingRight = true;
	}
	
	// Update is called once per frame
	void Update ()
    {
        float inX = Input.GetAxis("Horizontal");
        float inY = Input.GetAxis("Vertical");

        // Flip the character to face direction of movement
        if(inX < 0 && facingRight) {
            Flip();
        }
        else if(inX > 0 && !facingRight) {
            Flip();
        }

        movement = new Vector2(
            speed.x * inX,
            speed.y * inY    
        );


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
}
