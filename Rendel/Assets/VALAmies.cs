using UnityEngine;
using System.Collections;

public class VALAmies : MonoBehaviour 
{

    Vector3 targetPosition;
    Vector3 startPosition;
    float time;
    float timeTakenToLerp =2;
    bool isLerping;
    Rigidbody2D rb;

	void Start () 
    {
        targetPosition = transform.position;
        rb = GetComponent<Rigidbody2D>();
      
	}

    void FixedUpdate()
    {
        if(isLerping)
        {
            float timeSinceStarted = Time.time - time;
            float percentage = timeSinceStarted / timeTakenToLerp;
            rb.MovePosition( Vector3.Lerp(startPosition, targetPosition, percentage));

            if(percentage >=1)
            {
                isLerping = false;
                Global.Instance.setWorldState(eStates.PowerSwiping);
                rb.rotation =0;
                rb.angularVelocity = 0;
                rb.velocity = Vector2.zero;
                rb.isKinematic = false;
            }
        }
    }


    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "TaloPala" || col.gameObject.tag == "Talo")
        Global.Instance.setExplosion(col.transform.position + Vector3.right);
    }

    public void startLerp()
    {
        rb.isKinematic = true;
        isLerping = true;
        time = Time.time;
        startPosition = transform.position;
        rb.velocity = Vector2.zero;

    }
}
