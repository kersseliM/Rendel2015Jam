using UnityEngine;
using System.Collections;

public class BuildingPart : MonoBehaviour {

	// Use this for initialization
	void Start ()
    {
	
	}
	
    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag == "TaloPala")
        {
            MasterScoreSystem.Instanse.setEffect(col.contacts[0].point);
        }
    }
}
