using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movePlayer : MonoBehaviour {

	public float speed = 2.82f;
	//public Vector2 vecSpeed = new Vector2(-3,0);
	public float jumpSpeed = 8f;

	public static float currentRoom = 2.1f;

	private bool grounded = true;

	public string lastDir = "left"; //last direction the player was facing

	public GameObject fireball;

	public BoxCollider2D ownBoxCollider;

	public bool transferReady = true;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		 if (Input.GetKey(KeyCode.LeftArrow))
         {
             transform.position += Vector3.left * speed * Time.deltaTime;
			 lastDir = "left";
			 //GetComponent<Rigidbody2D>().MovePosition(GetComponent<Rigidbody2D>().position + vecSpeed * Time.deltaTime); //Vector based speed
         }
         if (Input.GetKey(KeyCode.RightArrow))
         {
             transform.position += Vector3.right * speed * Time.deltaTime;
			 lastDir = "right";
         }
         if (Input.GetKeyDown(KeyCode.UpArrow))
         {
			if(grounded == true)
			{
				//transform.position += Vector3.up * jumpSpeed * Time.deltaTime; //non-force-based jumping
				GetComponent<Rigidbody2D>().AddForce(new Vector2(0,jumpSpeed), ForceMode2D.Impulse);
				grounded = false;
			}
         }
         if (Input.GetKey(KeyCode.DownArrow))
         {
             transform.position += Vector3.down * speed * Time.deltaTime;
         }
		 if(Input.GetKeyDown(KeyCode.Space))
		 {
			if(transferReady == true)
            {
                transferReady = false;
                if(lastDir == "left")
                    Instantiate(fireball, transform.position - new Vector3(1.5f,0,0), transform.rotation);
                else if(lastDir == "right")
                    Instantiate(fireball, transform.position + new Vector3(1.5f,0,0), transform.rotation);
            }
		 }
		 if(Input.GetKeyDown(KeyCode.Escape))
		 {
			 Application.Quit();
		 }
	}

	void OnCollisionEnter2D(Collision2D hit)
	{
    	if (hit.gameObject.tag=="terrain" || hit.gameObject.tag=="platform")
		{
			//Debug.Log("Hit ground");
        	grounded=true;
		}
		else if (hit.gameObject.tag=="collapse"){
			//Debug.Log("Hit collapse collider");
			StartCoroutine(TimeToWait(hit.transform.parent.gameObject));
			//Destroy(hit.transform.parent.gameObject);
		}
	}
	void OnCollisionExit2D(Collision2D hit)
	{
		if (hit.gameObject.tag=="terrain" || hit.gameObject.tag=="platform")
		{
			//Debug.Log("Off ground");
			grounded=false;
		}
	}

	void OnTriggerEnter2D(Collider2D triggeredCollider)
	{
		if(triggeredCollider.name == "Two Way Platform Trigger")
			ownBoxCollider.isTrigger = true;
	}

	void OnTriggerExit2D(Collider2D triggeredCollider)
	{
		if(triggeredCollider.name == "Two Way Platform Trigger")
			ownBoxCollider.isTrigger = false;
	}
	IEnumerator TimeToWait(GameObject parentObject)
	{
		//Debug.Log("In TimeToWait");
		yield return new WaitForSeconds(3);
		Destroy(parentObject);
		//Debug.Log("Waiting is done");
	}

}
