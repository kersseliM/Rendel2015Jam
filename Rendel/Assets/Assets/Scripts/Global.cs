using UnityEngine;
using System.Collections;

public class Global : MonoBehaviour 
{
    GameObject scriptHolder;
    PowerSwipe pw;

    private static Global instance;
    public static Global Instance 
    {
        get { return instance; }
    }
    public eStates gameState;
    GameObject explosion;

	void Awake ()
    {
        scriptHolder = GameObject.Find("ScriptHolder");
        pw = scriptHolder.GetComponent<PowerSwipe>();

        if (instance != this && instance == null)
        {  
            instance = this;
        }
        else Destroy(gameObject);

        explosion = GameObject.Find("Explosion");
	}
	
    public void setWorldState(eStates state)
    {
        if (state == eStates.PowerSwiping)
        {
            powerSwiping();
        }
        print(state);
        gameState = state;
    }


    public void setExplosion(Vector3 pos)
    {
        explosion.transform.position = pos;
        explosion.SetActive(true);
    }

    public float totalForce;

    void powerSwiping()
    {
        pw.resetCurrentState();
    }
}
