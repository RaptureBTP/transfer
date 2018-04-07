using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blackout : MonoBehaviour {

	// Use this for initialization

	//private Transform[] blackouts;
	
	public List<KeyValuePair<double, string>> blackoutLocations = new List<KeyValuePair<double, string>>();
	
	public GameObject blackoutScreen;
	
	string[] transformValues;
	
	void Start ()
	{
		//13.35 apart on X axis, 10.025 apart on the Y axis
		blackoutLocations.Add(new KeyValuePair<double, string>(1.1, "-13.35,-9.9"));
		blackoutLocations.Add(new KeyValuePair<double, string>(1.2, "-13.35,0.125"));
		blackoutLocations.Add(new KeyValuePair<double, string>(2.1, "0,-9.9"));
		blackoutLocations.Add(new KeyValuePair<double, string>(2.2, "0,0.125"));
		blackoutLocations.Add(new KeyValuePair<double, string>(3.1, "13.35,-9.9"));
		blackoutLocations.Add(new KeyValuePair<double, string>(3.2, "13.35,0.125"));
		
		foreach(var location in blackoutLocations)
		{
			transformValues = location.Value.Split(',');
			
			Instantiate(blackoutScreen, new Vector3(Convert.ToSingle(transformValues[0]),Convert.ToSingle(transformValues[1]),0), transform.rotation);
			//Instantiate(blackoutScreen, new Vector3(4.3f,9.13f,0), transform.rotation);
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
