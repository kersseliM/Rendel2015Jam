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
    bool noMore;
    Animator anim;

	void Start () 
    {
        targetPosition = transform.position;
        rb = GetComponent<Rigidbody2D>();
        rb.isKinematic = true;
        audiosource = GetComponent<AudioSource>();
        anim = GetComponent<Animator>();
      
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
                endLerp();
            }
        }
    }


    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "TaloPala" || col.gameObject.tag == "Talo")
        Global.Instance.setExplosion(col.transform.position + Vector3.right);

        if (col.gameObject.tag == "Talo")
            rb.velocity = rb.velocity*2;

    }
    AudioSource audiosource;
    public void startLerp()
    {
        checkIfEndState();

        if (noMore)
            return;

        rb.isKinematic = true;
        isLerping = true;
        time = Time.time;
        startPosition = transform.position;
        rb.velocity = Vector2.zero;
        audiosource.Play();
    
    }
    void endLerp()
    {

        isLerping = false;
        Global.Instance.setWorldState(eStates.PowerSwiping);
        rb.rotation = 0;
        rb.angularVelocity = 0;
        rb.velocity = Vector2.zero;
        rb.isKinematic = true;
        rb.MovePosition (targetPosition);
    }


    void checkIfEndState()
    {
        Global.Instance.currentRound++;

        if(Global.Instance.currentRound >= Global.Instance.numberOfRounds)
        {  
      //      moveToHighscoreS

           Global.Instance.setWorldState(eStates.Endgame);
           noMore = true;
        }

     
    }
}
