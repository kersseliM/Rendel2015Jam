﻿using UnityEngine;
using System.Collections;

public class fastForward : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
        if(Input.GetMouseButtonDown(1))
        {
            Time.timeScale = Time.timeScale+1;
        }
	}
}
