﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

	public GameObject player;
	private Vector3 offset;

	// Use this for initialization
	void Start () {
		Screen.SetResolution(1024, 768, false);
		offset = transform.position - player.transform.position;
	}
	
	// LateUpdate is called once per frame, guarantees to run after all items have been processed in Update
	void LateUpdate () {
		transform.position = player.transform.position + offset;
	}
}
