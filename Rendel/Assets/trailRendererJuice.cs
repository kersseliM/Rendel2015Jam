using UnityEngine;
using System.Collections;

public class trailRendererJuice : MonoBehaviour
{
    public Vector3 tempDir;
    public Vector3 direction;
    public float speed;
    public float timeToStopTranslate;
    float time;
	// Use this for initialization
	void Start () 
    {
        tempDir = direction;
	}
	
	// Update is called once per frame
	void Update () 
    {
        time += Time.deltaTime;
        if(up == true)
        transform.Translate(tempDir*speed*Time.deltaTime, Space.Self);
	}

    public void a()
    {
        transform.localPosition = Vector3.zero;
        time = 0;
        tempDir = direction;
        up = true;
        Invoke("e",1);

    }

    public void gg()
    {
        direction = Vector3.zero;
        transform.localPosition = Vector3.zero;
        time = 0;
        up = false;
    }

    bool up =true;
    void e()
    {

        up = false;  
    }
}
