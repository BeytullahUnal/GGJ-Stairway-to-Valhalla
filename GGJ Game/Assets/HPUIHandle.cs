﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HPUIHandle : MonoBehaviour {

	public PlayerHealth PH;
	public Image HP1;
	public Image HP2;
	public Image HP3;
	// Use this for initialization
	void Awake ()
	{
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void HealthHandler()
	{
		if (PH.currenthealth <= 75 && PH.currenthealth >= 40) 
		{

		}

		if (PH.currenthealth < 40) {

		} 

		else 
		{

		}


	}
}
