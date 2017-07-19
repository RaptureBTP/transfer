using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectile : MonoBehaviour {

	private float speed = 6f;

	private string direction;
	public GameObject SpaceTransfer;
	// Use this for initialization
	void Start () 
	{
		//SpaceTransfer = GameObject.Find("SpaceTransfer");
		direction = GameObject.FindGameObjectWithTag("Player").GetComponent<movePlayer>().lastDir;
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
		if(col.gameObject.tag == "terrain")
		{
			DestroyObject(gameObject);
		}
		else if(col.gameObject.tag == "transferable")
		{
			if(col.gameObject.name == "Heart")
			{
				//SpaceTransfer.GetComponent<SpriteRenderer>().enabled = true;
				Instantiate(SpaceTransfer, new Vector3(-13.04f,0.06f,0), transform.rotation);
			}
			Destroy(col.gameObject);
			DestroyObject(gameObject);
		}
	}
}
