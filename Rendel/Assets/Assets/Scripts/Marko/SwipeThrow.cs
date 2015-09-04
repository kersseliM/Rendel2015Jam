using UnityEngine;
using System.Collections;

public class SwipeThrow : MonoBehaviour
{
    Vector3 startPos;
    Vector3 endPos;
    public float force;
    public Rigidbody2D VALAman;
    public ForceMode2D forceMode;
    public GameObject renderer;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Global.Instance.gameState == eStates.AngleSwiping)
        {
            if (Input.touchCount >= 1)
            {
                Touch t = Input.GetTouch(0);
                switch (t.phase)
                {
                    case TouchPhase.Began:
                        startPos = Camera.main.ScreenToWorldPoint(t.position);
                        break;
                    case TouchPhase.Ended:
                        endPos = Camera.main.ScreenToWorldPoint(t.position);
                        startPos = Camera.main.ScreenToWorldPoint(t.position);
                        calculateDirection();
                        break;
                }
            }

#if UNITY_EDITOR

            if (Input.GetMouseButtonDown(0))
                startPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if (Input.GetMouseButtonUp(0))
            {
                startPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                calculateDirection();
            }
#endif
        }
    }





    void calculateDirection()
    {
        Vector3 direction = startPos - endPos;
        direction = direction.normalized;
        direction = force*direction;
        VALAman.AddForce(direction, forceMode);
        Invoke("d", 0.1f);
        Global.Instance.setWorldState(eStates.Flying);
        
    }

    void d()
    {
        VALAman.AddTorque(50, ForceMode2D.Impulse);
        renderer.SetActive(true);
    }
}
