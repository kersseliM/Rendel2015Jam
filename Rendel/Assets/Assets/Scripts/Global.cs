using UnityEngine;
using System.Collections;

public class Global : MonoBehaviour 
{
    private static Global instance;
    public static Global Instance 
    {
        get { return instance; }
    }
    public eStates gameState;
    GameObject explosion;

	void Awake ()
    {
        if (instance != this && instance == null)
        {  
            instance = this;
        }
        else Destroy(gameObject);

        explosion = GameObject.Find("Explosion");
	}
	
    public void setWorldState(eStates state)
    {
        gameState = state;
    }


    public void setExplosion(Vector3 pos)
    {
        explosion.transform.position = pos;
        explosion.SetActive(true);
    }
}
