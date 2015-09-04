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

	void Awake ()
    {
        if (instance != this && instance == null)
        {  
            instance = this;
        }
        else Destroy(gameObject);
	}
	
    public void setWorldState(eStates state)
    {
        gameState = state;
    }
}
