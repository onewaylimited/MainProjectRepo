using UnityEngine;
using System.Collections;

public class RinkScript : MonoBehaviour {

    public bool leftTeam;

    private AudioSource audio;

	// Use this for initialization
	void Start () {
        audio = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D coll) {
        if (coll.gameObject.tag == "ball") print(leftTeam?"Right team scored!":"Left team scored!");
    }

    void OnCollisionEnter2D(Collision2D coll) {
        if(coll.gameObject.tag == "ball") {
            audio.Play();
        }
    }
}
