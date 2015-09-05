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
    bool checkIfStop;
    VALAmies valaMies;
    // Use this for initialization
    void Start()
    {
        valaMies = VALAman.gameObject.GetComponent<VALAmies>();
    }

    // Update is called once per frame
    void Update()
    {
        if (freezeVelocity)
            VALAman.velocity = Vector2.zero;
        else
        {

         //   roundVelocity();
            if (checkIfStop)
            {
                if (Global.Instance.gameState == eStates.Flying)
                {
                    if (VALAman.velocity == Vector2.zero)
                    {
                        checkIfStop = false;
                     //   Global.Instance.setWorldState(eStates.AngleSwiping);
                        valaMies.startLerp();
                        d();
                    }
                }
            }
        }

        

        if (Global.Instance.gameState == eStates.AngleSwiping)
        {

            /*
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

            */
            if (Input.GetMouseButtonDown(0))
                startPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if (Input.GetMouseButtonUp(0))
            {
                startPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                calculateDirection();
            }

        }
    }



    Vector3 forceHolder;
    bool freezeVelocity;
  public  float releaseVelocity;

    void calculateDirection()
    {
        Vector3 direction = startPos - endPos;
        direction = direction.normalized;
        direction = Global.Instance.totalForce*direction;
        VALAman.AddForce(direction, forceMode);
        VALAman.AddTorque(50, ForceMode2D.Impulse);
        Global.Instance.setWorldState(eStates.Flying);
        forceHolder = direction;
        muutaPaskaa();
    }

    void roundVelocity()
    {
        Vector3 vel = VALAman.velocity;
        vel.x = Mathf.Round(VALAman.velocity.x);
        vel.y = Mathf.Round(VALAman.velocity.y);
        VALAman.velocity = vel;
    }
    void muutaPaskaa()
    {
        renderer.SetActive(true);
        freezeVelocity = true;
        Invoke("d", releaseVelocity);
        Invoke("b", 4);
    }
    void d()
    {
        freezeVelocity = false;
        VALAman.velocity = forceHolder;

        foreach (Transform t in renderer.transform)
        {
            t.gameObject.SendMessage("a");
        }
    }

    void b()
    {
        checkIfStop = true;
    }
}
