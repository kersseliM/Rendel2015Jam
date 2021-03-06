﻿using UnityEngine;
using System.Collections;

[System.Serializable]
public  struct cameraValues
{
   public Vector3 adjustments;
   public float zoom;
   public float lerpSpeed;
   public Transform target;
}
public class SmoothCamera : MonoBehaviour 
{
   [SerializeField]
    cameraValues AngleSwipeValues;
   [SerializeField]
   cameraValues PowerSwipeValues;
   [SerializeField]
   cameraValues FlyingValues;
    public Transform target;
    [SerializeField]
    cameraValues IntroValues;

	void Update () 
    {
        switch(Global.Instance.gameState)
        {
            case eStates.Intro: setValues(IntroValues); break;
            case eStates.Flying: setValues(FlyingValues);break;
            case eStates.PowerSwiping: setValues(PowerSwipeValues); break;
            case eStates.AngleSwiping: setValues(AngleSwipeValues); break;
        }
	}

    void setValues(cameraValues eCameraValues)
    {
        Vector3 cameraNewPos = target.position;
        cameraNewPos.x = target.position.x+ eCameraValues.adjustments.x;
        cameraNewPos.y = target.position.y+ eCameraValues.adjustments.y;
        cameraNewPos.z = -10;
        transform.position = Vector3.Lerp(transform.position, cameraNewPos, Time.deltaTime * eCameraValues.lerpSpeed);

        if (Camera.main.orthographicSize != eCameraValues.zoom)
            Camera.main.orthographicSize = Mathf.Lerp(Camera.main.orthographicSize, eCameraValues.zoom,Time.deltaTime*eCameraValues.lerpSpeed);

        if (target != eCameraValues.target)
            target = eCameraValues.target;
    }
}
