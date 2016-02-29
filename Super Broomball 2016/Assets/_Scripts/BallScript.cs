using UnityEngine;
using System.Collections;

public class BallScript : MonoBehaviour {

    
    Rigidbody2D player;
    public bool inPossession;

    private Vector3 startPos;
    private AudioSource source;


	// Use this for initialization
	void Start () {
        startPos = transform.position;
        source = GetComponent<AudioSource>();
	}

    public void returnToCenter() {
        transform.position = startPos;
        GetComponent<Rigidbody2D>().velocity = Vector2.zero;
    }
	
	// Update is called once per frame
	void Update () {
        
	}
}
