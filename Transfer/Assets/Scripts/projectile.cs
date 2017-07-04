using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectile : MonoBehaviour {

	public float speed = 3f;
	// Use this for initialization
	void Start () 
	{
		
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
			Destroy(col.gameObject);
			DestroyObject(gameObject);
		}
	}
}
