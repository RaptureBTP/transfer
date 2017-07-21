using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectileTD : MonoBehaviour {

	private float speed = 6f;

	private string direction;
	public GameObject SpaceTransfer;
	public GameObject HeartWall;
	// Use this for initialization
	void Start () 
	{
		//SpaceTransfer = GameObject.Find("SpaceTransfer");
		direction = GameObject.FindGameObjectWithTag("Player").GetComponent<movePlayerTD>().lastDir;
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
		if(col.gameObject.tag == "terrain")
		{
			DestroyObject(gameObject);
		}
		else if(col.gameObject.tag == "transferable")
		{
            Destroy(col.gameObject);
			if(col.gameObject.name == "Heart")
			{
				//Debug.Log(GameObject.Find("Wall-Heart-TD"));
				Destroy(GameObject.Find("Wall-Heart-TD"));
				//SpaceTransfer.GetComponent<SpriteRenderer>().enabled = true;
				Instantiate(SpaceTransfer, new Vector3(-5.04f,-1.8f,0), transform.rotation);
				Instantiate(HeartWall, new Vector3(-3.79f, 3.4f, -1.24f), Quaternion.Euler (0,0,270));
			}
			DestroyObject(gameObject);
		}
        GameObject.FindGameObjectWithTag("Player").GetComponent<movePlayerTD>().transferReady = true;
	}
}
