using UnityEngine;
using System.Collections;

public class BallScript : MonoBehaviour {

    
    Rigidbody2D player;
    public bool inPossession;


    private AudioSource source;


	// Use this for initialization
	void Start () {
        source = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
        
	}
}
