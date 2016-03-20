using UnityEngine;
using System.Collections;

public class GoalieScript : MonoBehaviour
{

    public GameObject ball = null;
    private GameObject player = null;
    private bool dangerZone = false;
    // Use this for initialization
    void Start()
    {
        player = this.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (dangerZone)
        {
            Block();
        }
    }

    void OnTriggerEnter2D(Collider2D coll)
    {

        if (coll.gameObject.tag == "ball")
        {
            //ball is nearby
            ball = coll.gameObject;
            dangerZone = true;
        }
    }


    void OnTriggerExit2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "ball")
        {
            ball = null;
            dangerZone = false;
        }
    }
    void Block()
    {
        if (ball.GetComponent<Transform>().position.y > player.GetComponent<Transform>().position. y)
        {
            player.GetComponent<Rigidbody2D>().AddForce(new Vector3(0, 5, 0));
        }
        else if (ball.GetComponent<Transform>().position.y < player.GetComponent<Transform>().position.y)
        {
            player.GetComponent<Rigidbody2D>().AddForce(new Vector3(0, -5, 0));
        }
    }
}
