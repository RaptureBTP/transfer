using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectile : MonoBehaviour {

	public float speed = 3f;
	public GameObject SpaceTransfer;
	// Use this for initialization
	void Start () 
	{
		//SpaceTransfer = GameObject.Find("SpaceTransfer");
	}
	
	// Update is called once per frame
	void Update () 
	{
		transform.position += Vector3.left * speed * Time.deltaTime;
	}
	
	void OnTriggerEnter2D(Collider2D col)
	{
		if(col.gameObject.tag == "transferable")
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
