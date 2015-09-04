using UnityEngine;
using System.Collections;

public class SmoothCamera : MonoBehaviour {
   
    struct cameraValue
    {
        Vector3 adjustments;
        float Zoom;
    }


    
    
    public GameObject Target;
   
	void Update () 
    {
        switch(Global.Instance.gameState)
        {
            case eStates.Intro: break;
            case eStates.Flying: break;
            case eStates.PowerSwiping: break;
            case eStates.AngleSwiping: break;
        }
	}



    void AngleSwipe()
    {


    }

}
