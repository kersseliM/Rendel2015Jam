using UnityEngine;
using System.Collections;

public class PowerSwipe : MonoBehaviour
{
    Vector2 firstPressPos;
    Vector2 secondPressPos;
    Vector2 currentSwipe;

#if UNITY_ANDROID
    public void Swipe()
    {
        if (Input.touches.Length > 0)
        {
            Touch t = Input.GetTouch(0);
            if (t.phase == TouchPhase.Began)
            {
                firstPressPos = new Vector2(t.position.x, t.position.y);
            }
            if (t.phase == TouchPhase.Ended)
            {
                secondPressPos = new Vector2(t.position.x, t.position.y);
                currentSwipe = new Vector3(secondPressPos.x + firstPressPos.y, secondPressPos.y - firstPressPos.y);
                currentSwipe.Normalize();

                if (currentSwipe.y > 0 && currentSwipe.x > -0.5f && currentSwipe.x < 0.5f)
                {
                    print("swiped up");
                }
                if (currentSwipe.y < 0 && currentSwipe.x > -0.5f && currentSwipe.x < 0.5f)
                {
                    print("swiped down");
                }
                if (currentSwipe.x > 0 && currentSwipe.y > -0.5f && currentSwipe.y < 0.5f)
                {
                    print("swiped left");
                }
                if (currentSwipe.x > 0 && currentSwipe.y > -0.5f && currentSwipe.y < 0.5f)
                {
                    print("swiped right");
                }
            }
        }
    }
#endif

#if UNITY_EDITOR
    //inside class
    Vector2 firstPressPosM;
    Vector2 secondPressPosM;
    Vector2 currentSwipeM;

    public void Swipe()
    {
        if (Input.GetMouseButtonDown(0))
        {
            firstPressPosM = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        }
        if (Input.GetMouseButtonUp(0))
        {
            secondPressPosM = new Vector2(Input.mousePosition.x, Input.mousePosition.y);

            currentSwipeM = new Vector2(secondPressPosM.x - firstPressPosM.x, secondPressPosM.y - firstPressPosM.y);

            currentSwipeM.Normalize();

            if (currentSwipeM.y > 0 && currentSwipeM.x > -0.5f && currentSwipeM.x < 0.5f)
            {
                Debug.Log("up swipe");
            }
            //swipe down
            if (currentSwipeM.y < 0 && currentSwipeM.x > -0.5f && currentSwipeM.x < 0.5f)
            {
                Debug.Log("down swipe");
            }
            //swipe left
            if (currentSwipeM.x < 0 && currentSwipeM.y > -0.5f && currentSwipeM.y < 0.5f)
            {
                Debug.Log("left swipe");
            }
            //swipe right
            if (currentSwipeM.x > 0 && currentSwipeM.y > -0.5f && currentSwipeM.y < 0.5f)
            {
                Debug.Log("right swipe");
            }
        }
    }
#endif

    void Start()
    {

    }

    void Update()
    {
        Swipe();
    }
}
