using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectile : MonoBehaviour {

	private float speed = 6f;

	private string direction;
	public GameObject SpaceTransfer;
	//public GameObject HeartWall;
	// Use this for initialization
	void Start () 
	{
		//SpaceTransfer = GameObject.Find("SpaceTransfer");
		direction = GameObject.FindGameObjectWithTag("Player").GetComponent<movePlayer>().lastDir;
        //Debug.Log(direction);
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(direction == "left")
			transform.position += Vector3.left * speed * Time.deltaTime;
		else if(direction == "right")
			transform.position += Vector3.right * speed * Time.deltaTime;
	}
	
	void OnTriggerEnter2D(Collider2D col)
	{
		Debug.Log(col.gameObject.name);
		if(col.gameObject.tag == "terrain" || col.gameObject.tag == "platform")
		{
			DestroyObject(gameObject);
		}
		else if(col.gameObject.tag == "transferable")
		{
			Instantiate(SpaceTransfer, col.transform.position, transform.rotation);
            Destroy(col.gameObject);
			// if(col.gameObject.name == "Heart")
			// {
			// 	//Debug.Log(GameObject.Find("Wall-Heart-TD"));
			// 	//Destroy(GameObject.Find("Wall-Heart-TD"));
			// 	//SpaceTransfer.GetComponent<SpriteRenderer>().enabled = true;
			// 	//col.Collider2D.transform.position;
			// 	Instantiate(SpaceTransfer, col.transform.position, transform.rotation);
			// 	//Instantiate(SpaceTransfer, new Vector3(-5.04f,-1.8f,0), transform.rotation);
			// 	//Instantiate(HeartWall, new Vector3(-3.79f, 3.4f, -1.24f), Quaternion.Euler (0,0,270));
			// }
			DestroyObject(gameObject);
		}
		if(col.gameObject.tag != "background")
        	GameObject.FindGameObjectWithTag("Player").GetComponent<movePlayer>().transferReady = true;
	}
}
