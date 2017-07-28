using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movePlayerED : MonoBehaviour {

	public float speed = 2.82f;
	//public Vector2 vecSpeed = new Vector2(-3,0);
	//public float jumpSpeed = 4f;

	//public static float currentRoom = 2.1f;

	private bool grounded = true;

    private bool dialRange = false;

    GameObject[] roomBlackouts;

    //public bool transferReady = true;

	//public string lastDir = "left";

	//public GameObject fireball;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		 if (Input.GetKey(KeyCode.LeftArrow))
         {
             transform.position += Vector3.left * speed * Time.deltaTime;
			 //lastDir = "left";
             //Debug.Log("Player moved " + lastDir + " last");
			 //GetComponent<Rigidbody2D>().MovePosition(GetComponent<Rigidbody2D>().position + vecSpeed * Time.deltaTime); //Vector based speed
         }
         if (Input.GetKey(KeyCode.RightArrow))
         {
             transform.position += Vector3.right * speed * Time.deltaTime;
			 //lastDir = "right";
             //Debug.Log("Player moved " + lastDir + " last");
         }
         if (Input.GetKeyDown(KeyCode.UpArrow))
         {
			if(grounded == true)
			{
				//transform.position += Vector3.up * jumpSpeed * Time.deltaTime; //non-force-based jumping
				GetComponent<Rigidbody2D>().AddForce(new Vector2(0,5), ForceMode2D.Impulse);
			}
         }
         if (Input.GetKey(KeyCode.DownArrow))
         {
             transform.position += Vector3.down * speed * Time.deltaTime;
         }
		//  if(Input.GetKey(KeyCode.Space))
		//  {
        //     if(transferReady == true)
        //     {
        //         transferReady = false;
        //         if(lastDir == "left")
        //             Instantiate(fireball, transform.position - new Vector3(1.5f,0,0), transform.rotation);
        //         else if(lastDir == "right")
        //             Instantiate(fireball, transform.position + new Vector3(1.5f,0,0), transform.rotation);
        //     }
		//  }
        if(Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("Pressed E");
            if(dialRange)
            {
                roomBlackouts = GameObject.FindGameObjectsWithTag("hiddenRoomOverlay");
                Destroy(roomBlackouts[0]);  
            }
        }
		if(Input.GetKeyDown(KeyCode.Escape))
		{
			Application.Quit();
		}
	}

	void OnCollisionEnter2D(Collision2D hit)
	{
    	if (hit.gameObject.tag=="terrain")
		{
			Debug.Log("Hit ground");
        	grounded=true;
		}
	}
	void OnCollisionExit2D(Collision2D hit)
	{
		if (hit.gameObject.tag=="terrain")
		{
			Debug.Log("Off ground");
			grounded=false;
		}
	}
    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "dial")
        {
            Debug.Log("Collided with dial");
            dialRange = true;
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if(col.gameObject.tag == "dial")
        {
            Debug.Log("Left dial area");
            dialRange = false;
        }
    }

    // void FindBlackouts(){
	// 	roomBlackouts = GameObject.FindGameObjectsWithTag("hiddenRoomOverlay");
	// }

}
