using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movePlayer : MonoBehaviour {

	public float speed = 5f;
	//public Vector2 vecSpeed = new Vector2(-3,0);
	public float jumpSpeed = 10f;

	public static float currentRoom = 2.1f;

	public GameObject fireball;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		 if (Input.GetKey(KeyCode.LeftArrow))
         {
             transform.position += Vector3.left * speed * Time.deltaTime;
			 //GetComponent<Rigidbody2D>().MovePosition(GetComponent<Rigidbody2D>().position + vecSpeed * Time.deltaTime); //Vector based speed
         }
         if (Input.GetKey(KeyCode.RightArrow))
         {
             transform.position += Vector3.right * speed * Time.deltaTime;
         }
         if (Input.GetKeyDown(KeyCode.UpArrow))
         {
             //transform.position += Vector3.up * jumpSpeed * Time.deltaTime; //non-force-based jumping
			 GetComponent<Rigidbody2D>().AddForce(new Vector2(0,8), ForceMode2D.Impulse);
         }
         if (Input.GetKey(KeyCode.DownArrow))
         {
             transform.position += Vector3.down * speed * Time.deltaTime;
         }
		 if(Input.GetKeyDown(KeyCode.Space))
		 {
			Instantiate(fireball, transform.position - new Vector3(1.5f,0,0), transform.rotation);
		 }
		 if(Input.GetKeyDown(KeyCode.Escape))
		 {
			 Application.Quit();
		 }
	}
}
