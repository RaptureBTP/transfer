using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lightRoomTD : MonoBehaviour {

	public GameObject blackoutSpace;
	public float minimumDistance = 10f;
	private bool triggerWait = false;
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
		//Debug.Log("Collided");
		Debug.Log(movePlayer.currentRoom);
		FindBlackouts();

		if(other.tag == "Player")
		{
			Debug.Log("Collided with player");

			if(triggerWait == false)
			{	
				//triggerWait = true;
				if(movePlayer.currentRoom == 1.1f){
                    Debug.Log("Created new blackout in room 2.1");
					Instantiate(blackoutSpace, new Vector3(-10.94f, 1.32f, 0), transform.rotation);
				}
				else if(movePlayer.currentRoom == 2.1f)
				{
                    Debug.Log("Created new blackout in room 1.1");
					Instantiate(blackoutSpace, new Vector3(3.357267f, 1.351677f, 0), transform.rotation);
				}
				

				for (int i = 0; i < roomBlackouts.Length; ++i)
				{
					if(roomBlackouts[i] != null){
                        Debug.Log("Distance from " + roomBlackouts[i] + " and collider is " + Vector3.Distance(transform.position, roomBlackouts[i].transform.position));
						if(Vector3.Distance(transform.position, roomBlackouts[i].transform.position) <= minimumDistance)
						{
								Destroy(roomBlackouts[i]);
                                //Debug.Log("Destroyed something.");
						}
					}
				}

				if(movePlayer.currentRoom == 1.1f)
					movePlayer.currentRoom = 2.1f;
				else
					movePlayer.currentRoom = 1.1f;

				//if(other.collider2D.GetComponent<>())

				//Instantiate(blackoutSpace,,); //instantiate 
				// StartCoroutine(DoorCooldown());
			}
		}
	}

	void FindBlackouts(){
		roomBlackouts = GameObject.FindGameObjectsWithTag("hiddenRoomOverlay");
	}

	// IEnumerator DoorCooldown()
	// {
	// 	yield return new WaitForSecondsRealtime(1);
	// 	triggerWait = false;
	// }

}
