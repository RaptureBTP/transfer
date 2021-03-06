﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lightRoom : MonoBehaviour {

	public GameObject blackoutSpace;
	//public float minimumDistance = 5;
	public static GameObject[] roomBlackouts;
	public float roomNum = 2.1f;
	public string prevRoomTransform;
	string[] transformValues;
	string[] newBlackoutTransformValues;
	//public GameObject blackoutSpaceExit;
	//private bool triggerWait = false;
	
	

	// Use this for initialization
	void Start () {
		FindBlackouts();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.tag == "Player")
		{
			Debug.Log("Player collided");
			Debug.Log("Player current room before changing: " + movePlayer.currentRoom);
			Debug.Log("Player previous room before changing: " + movePlayer.previousRoom);
			movePlayer.previousRoom = movePlayer.currentRoom; //save current player room as the previous room
			movePlayer.currentRoom = roomNum; //update current room for this specific room.
			Debug.Log("New Player Current Room: " + movePlayer.currentRoom);
			Debug.Log("New Player Previous Room: " + movePlayer.previousRoom);
			
				foreach(var location in Blackout.blackoutLocations)//get the transform of previous room
				{
					if(Convert.ToSingle(location.Key) == movePlayer.currentRoom) //compare the keyvalue's key to the previous room number
					{
						//Debug.Log("Found previous room transform match");
						transformValues = location.Value.Split(',');
						//Debug.Log("Previous room transform: " + transformValues[0] + " " + transformValues[1]);
					}
					else if(Convert.ToSingle(location.Key) == movePlayer.previousRoom)
					{
						//Debug.Log("Found new blackout transform values.");
						newBlackoutTransformValues = location.Value.Split(',');
						//Debug.Log("New room blackout transform: " +newBlackoutTransformValues[0] + " " + newBlackoutTransformValues[1]);

					}
				}
				
				//get all the blackouts
				lightRoom.FindBlackouts();
				
				//go through each blackout
				for (int i = 0; i < lightRoom.roomBlackouts.Length; ++i)
				{
					if(roomBlackouts[i] != null){
						//Debug.Log(roomBlackouts[i].transform.position);
						if(roomBlackouts[i].transform.position.x == Convert.ToSingle(transformValues[0]) && roomBlackouts[i].transform.position.y == Convert.ToSingle(transformValues[1])) //compare its transform to transform of previous rooms blackout
						{
							//Debug.Log("Found position match. Destroying blackout and location: " + transformValues[0] + " " + transformValues[1]);
							//Destroy(roomBlackouts[i]); //destroy previous rooms blackout
						}
					}
				}
				if(movePlayer.currentRoom != movePlayer.previousRoom)
				{
					//Debug.Log("Instantiating new blackout in previous room, location: " + newBlackoutTransformValues[0] + " " + newBlackoutTransformValues[1]);
					Instantiate(blackoutSpace, new Vector3(Convert.ToSingle(newBlackoutTransformValues[0]), Convert.ToSingle(newBlackoutTransformValues[1]), 0), transform.rotation);
				}
		/*Debug.Log("Collided between rooms");
		Debug.Log(movePlayer.currentRoom); //log out the players current room i.e. the room they just left
		
		movePlayer.previousRoom=movePlayer.currentRoom; //update room
		//movePlayer.currentRoom = ;
		
		FindBlackouts();

		if(other.tag == "Player")
		{
			// GameObject playerObj = other.transform.parent.gameObject;
			// playerObj.GetComponent<
			Debug.Log("Collided with player");

			//if(triggerWait == false)
			//{	
				//triggerWait = true;
				if(movePlayer.currentRoom == 2.1f){
					Instantiate(blackoutSpace, new Vector3(4.3f, -0.07f, 0), transform.rotation);
				}
				else if(movePlayer.currentRoom == 2.2f)
				{
					Instantiate(blackoutSpace, new Vector3(4.3f,9.13f,0), transform.rotation);
				}
				

				for (int i = 0; i < roomBlackouts.Length; ++i)
				{
					if(roomBlackouts[i] != null){
						if(Vector3.Distance(transform.position, roomBlackouts[i].transform.position) <= minimumDistance)
						{
								Destroy(roomBlackouts[i]);
						}
					}
				}

/* 				if(movePlayer.currentRoom == 2.1f)
					movePlayer.currentRoom = 2.2f;
				else
					movePlayer.currentRoom = 2.1f; */

				//if(other.collider2D.GetComponent<>())

				//Instantiate(blackoutSpace,,); //instantiate 
				// StartCoroutine(DoorCooldown());
			//}
		//}
		}
	} 

	public static void FindBlackouts(){
		roomBlackouts = GameObject.FindGameObjectsWithTag("hiddenRoomOverlay");
	}

	// IEnumerator DoorCooldown()
	// {
	// 	yield return new WaitForSecondsRealtime(1);
	// 	triggerWait = false;
	// }

}
