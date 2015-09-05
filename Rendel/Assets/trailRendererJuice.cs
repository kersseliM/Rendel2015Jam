using UnityEngine;
using System.Collections;

public class trailRendererJuice : MonoBehaviour
{
    public Vector3 direction;
    public float speed;
    public float timeToStopTranslate;
    float time;
	// Use this for initialization
	void Start () 
    {
	
	}
	
	// Update is called once per frame
	void Update () 
    {
        time += Time.deltaTime;
        transform.Translate(direction*speed*Time.deltaTime, Space.Self);
        if (timeToStopTranslate > time)
            enabled = false;
	}

    public void a()
    {
        transform.localPosition = Vector3.zero;
        time = 0;
    }
}
