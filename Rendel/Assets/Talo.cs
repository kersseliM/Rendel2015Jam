using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Talo : MonoBehaviour
{
    List<Rigidbody2D> myChilds = new List<Rigidbody2D>();
	// Use this for initialization
	void Start () 
    {
	foreach(Transform t in transform)
    {

        if(t.childCount > 0)
        {
            foreach(Transform g in t)
            {
                if (g.GetComponent<Rigidbody2D>() != null)
                    myChilds.Add(g.GetComponent<Rigidbody2D>());
            }
        }

        if (t.GetComponent<Rigidbody2D>() != null)
            myChilds.Add(t.GetComponent<Rigidbody2D>());
    }

	}
	

    void releaseTheBodies()
    {
        foreach(Rigidbody2D r in myChilds)
        {
            r.isKinematic = false;
            r.gameObject.tag = "TaloPala" ;
            r.transform.parent = null;
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "VALA")
        {
            releaseTheBodies();
            gameObject.SetActive(false);
        }
    }
}
