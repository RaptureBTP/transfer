using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackoutSceneED : MonoBehaviour {

	// Use this for initialization
	private Transform[] blackouts;
	public GameObject blackoutScreen;
	void Start () {
		//blackouts[0]
		Instantiate(blackoutScreen, new Vector3(-0.98f,-2.84f,0), transform.rotation);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
