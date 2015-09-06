﻿using UnityEngine;
using System.Collections;

public class BuildingPart : MonoBehaviour {

    
    Rigidbody2D RB;	// Use this for initialization
	void Start ()
    {
        GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 255);
	}
	

 

    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag == "TaloPala")
        {
            MasterScoreSystem.Instanse.setEffect(col.contacts[0].point);
        }

        if (col.gameObject.tag == "VALA")
        {
            Destroy(gameObject);
        }
    }
}
