using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lightRoom : MonoBehaviour {

	//public GameObject blackoutSpace;
	public float minimumDistance = 10;
	GameObject[] roomBlackouts;
	//public GameObject blackoutSpaceExit;

	// Use this for initialization
	void Start () {
		FindBlackouts();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D other){
		System.Console.WriteLine("Collided");
		if(other.tag == "Player")
		{
			System.Console.WriteLine("Collided with player");
			for (int i = 0; i < roomBlackouts.Length; ++i)
			{
				if(roomBlackouts[i] != null){
					if(Vector3.Distance(transform.position, roomBlackouts[i].transform.position) <= minimumDistance)
					{
							Destroy(roomBlackouts[i]);
					}
				}
			}
     
			//Instantiate(blackoutSpace,,); //instantiate 
		}
	}

	void FindBlackouts(){
		roomBlackouts = GameObject.FindGameObjectsWithTag("hiddenRoomOverlay");
	}
}
