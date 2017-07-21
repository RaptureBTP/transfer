using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackoutTDScene : MonoBehaviour {

	// Use this for initialization
	private Transform[] blackouts;
	public GameObject blackoutScreen;
	void Start () {
		//blackouts[0]
		Instantiate(blackoutScreen, new Vector3(-10.94f,1.32f,0), transform.rotation);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
