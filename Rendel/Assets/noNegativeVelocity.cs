using UnityEngine;
using System.Collections;

public class noNegativeVelocity : MonoBehaviour
{
    Rigidbody2D rb;


    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

	void Update () 
    {
        if (rb.velocity.x < 0)
        {
            Vector3 newVel = rb.velocity;
            newVel.x =  Mathf.Round( Mathf.Abs(rb.velocity.x));
            rb.velocity = newVel;
        }
	}
}
