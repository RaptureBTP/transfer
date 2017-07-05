using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lightRoom : MonoBehaviour {

	public GameObject blackoutSpace;
	//public GameObject blackoutSpaceExit;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2d(Collider2D other){
		if(other.tag == "Player")
		{
			//Instantiate(blackoutSpace,,); //instantiate 
		}
	}
}
