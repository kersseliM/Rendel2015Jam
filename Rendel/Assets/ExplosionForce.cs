using UnityEngine;
using System.Collections;

public class ExplosionForce : MonoBehaviour 
{

    public float timeToGoOff;
    PointEffector2D pe;
    public float säätö;
    CircleCollider2D circleCol;
    public float circleSäätö=0.25f;
    void Awake()
    {
        circleCol = GetComponent<CircleCollider2D>();
        pe = GetComponent<PointEffector2D>();
    }
    void OnEnable()
    {
        Invoke("a", timeToGoOff);
        if(Global.Instance != null)
        pe.forceMagnitude = Global.Instance.totalForce *säätö ;
      //  circleCol.radius = Global.Instance.totalForce * circleSäätö;
    }
    void a()
    {
        gameObject.SetActive(false);

    }
}
