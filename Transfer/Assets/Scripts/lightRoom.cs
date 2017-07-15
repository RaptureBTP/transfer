using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lightRoom : MonoBehaviour {

	public GameObject blackoutSpace;
	public float minimumDistance = 5;
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
		Debug.Log("Collided");
		Debug.Log(movePlayer.currentRoom);
		FindBlackouts();

		if(other.tag == "Player")
		{
			// GameObject playerObj = other.transform.parent.gameObject;
			// playerObj.GetComponent<
			Debug.Log("Collided with player");

			if(triggerWait == false)
			{	
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

				if(movePlayer.currentRoom == 2.1f)
					movePlayer.currentRoom = 2.2f;
				else
					movePlayer.currentRoom = 2.1f;

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
