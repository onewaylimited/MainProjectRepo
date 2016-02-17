using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour {

    private Vector2 speed = new Vector2(5, 5);

    private Vector2 movement;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        float inX = Input.GetAxis("Horizontal");
        float inY = Input.GetAxis("Vertical");

        movement = new Vector2(
            speed.x * inX,
            speed.y * inY    
        );
    }

    void FixedUpdate()
    {
        GetComponent<Rigidbody2D>().velocity = movement;
    }
}
