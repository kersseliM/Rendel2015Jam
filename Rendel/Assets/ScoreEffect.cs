using UnityEngine;
using System.Collections;

public class ScoreEffect : MonoBehaviour 
{

    float  targetAlfa=0;
   float startAlfa=1;
    float time;
    float timeTakenToLerp = 1;
    bool isLerping;
    SpriteRenderer sr;
   

    void Awake()
    {
        MasterScoreSystem.Instanse.addMeToList(gameObject);
    }

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }


    void OnEnable()
    {
        startLerp();
    }

    void FixedUpdate()
    {
        if (isLerping)
        {
            float timeSinceStarted = Time.time - time;
            float percentage = timeSinceStarted / timeTakenToLerp;

            Color c = sr.color;
            c.a = Mathf.Lerp(startAlfa, targetAlfa, percentage);
            sr.color = c;

            if (percentage >= 1)
            {
                isLerping = false;
               // Global.Instance.setWorldState(eStates.PowerSwiping);
                gameObject.SetActive(false);
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
        isLerping = true;
        time = Time.time;
    }
}
