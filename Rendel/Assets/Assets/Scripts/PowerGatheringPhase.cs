using UnityEngine;
using System.Collections;

public class PowerGatheringPhase : MonoBehaviour
{

    float timer;
    bool isGatheringAllowed;
    float gatheringTime;

    void Start()
    {

    }

    void Update()
    {
        timer += 1 * Time.deltaTime;
        //print(timer);
        if (timer <= gatheringTime)
        {
            isGatheringAllowed = true;
        }
    }

    public float GetTime()
    {
        return timer;
    }

    public void ResetTimer()
    {
        timer = 0;
    }

    public bool IsAllowed()
    {
        return isGatheringAllowed;
    }
}
