using UnityEngine;
using System.Collections;

public class ExplosionForce : MonoBehaviour 
{

    public float timeToGoOff;
    PointEffector2D pe;
    public float säätö;

    void Awake()
    {
        pe = GetComponent<PointEffector2D>();
    }
    void OnEnable()
    {
        Invoke("a", timeToGoOff);
        if(Global.Instance != null)
        pe.forceMagnitude = Global.Instance.totalForce *säätö ;
    }
    void a()
    {
        gameObject.SetActive(false);

    }
}
