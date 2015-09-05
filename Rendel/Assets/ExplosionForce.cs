using UnityEngine;
using System.Collections;

public class ExplosionForce : MonoBehaviour 
{

    public float timeToGoOff;
    void OnEnable()
    {
        Invoke("a", timeToGoOff);

    }
    void a()
    {
        gameObject.SetActive(false);

    }
}
