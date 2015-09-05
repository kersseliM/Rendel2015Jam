using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PowerSwipe : MonoBehaviour
{
    enum SwipeDirection
    {
        Up,
        Down,
        Left,
        Right
    }

    Vector2 firstPressPos;
    Vector2 secondPressPos;
    Vector2 currentSwipe;

    public Rigidbody2D VALAman;
    public Text Direction;
    public Text PointsText;
    public Text PowerText;
    public Text InfoText;
    public Text timeLeftText;

    public float IntroDelay = 4;
    public float SwipeTime = 5;
    public int PowerValue = 5;

    int currentAction;
    string playerInputAction = " ";
    string upAction = "Up";
    string downAction = "Down";
    string leftAction = "Left";
    string rightAction = "Right";

    float swipeTimer;   
    float gameTime;
    float randomizer;
    SwipeDirection randomSwipeDir;
    string givenSwipeDir;
    bool giveNewDirection;
    bool startSwipeTimer;

    int power;

    void Start()
    {
        swipeTimer = SwipeTime;
        giveNewDirection = true;
        startSwipeTimer = false;
    }

    void Update()
    {
        if (Global.Instance.gameState == eStates.PowerSwiping)
        {
            updateTimers();
            intro();
            if (gameTime > IntroDelay)
            {
                startSwipeTimer = true;
                if (giveNewDirection == true)
                {
                    randomSwipeDir = getRandomEnum<SwipeDirection>();
                    givenSwipeDir = randomSwipeDir.ToString();
                    Direction.text = givenSwipeDir;
                    giveNewDirection = false;
                }
            }

            if (swipeTimer > 0 && startSwipeTimer == true)
            {
                Swipe();
                bool tempBool = isCorrectDirection();
                if (tempBool)
                {
                    power += PowerValue;
                    giveNewDirection = true;
                }
            }
            if (swipeTimer <= 0)
            {
                startNextPhase();
            }
        }      
    }

    void LateUpdate()
    {
        timeLeftText.text = Mathf.Round(swipeTimer).ToString();      
        PowerText.text = power.ToString();
    }

    void intro()
    {
        if (gameTime >= 0 && gameTime < 3)
        {
            InfoText.text = "READY";
        }
        if (gameTime >= 3 && gameTime < 4)
        {
            InfoText.text = "GO";
        }
        if (gameTime >= 4)
        {
            InfoText.text = "";
        }
    }

    void updateTimers()
    {
        if (startSwipeTimer == true)
        {
            swipeTimer -= 1 * Time.deltaTime;
        }

        if (swipeTimer <= 0)
        {
            swipeTimer = 0;
        }
        gameTime += 1 * Time.deltaTime;
    }

    bool isCorrectDirection()
    {
        if (playerInputAction == givenSwipeDir)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    void resetCurrentState()
    {
        gameTime = 0;
    }

    void startNextPhase()
    {
        Global.Instance.setWorldState(eStates.AngleSwiping);
    }

    static T getRandomEnum<T>()
    {
        System.Array arr = System.Enum.GetValues(typeof(T));
        T randomValue = (T)arr.GetValue(UnityEngine.Random.Range(0, arr.Length));
        return randomValue;
    }

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
                    //swipe up
                    playerInputAction = upAction;
                }
                if (currentSwipe.y < 0 && currentSwipe.x > -0.5f && currentSwipe.x < 0.5f)
                {
                    //swipe down
                    playerInputAction = downAction;
                }
                if (currentSwipe.x > 0 && currentSwipe.y > -0.5f && currentSwipe.y < 0.5f)
                {
                    //swipe left
                    playerInputAction = leftAction;
                }
                if (currentSwipe.x > 0 && currentSwipe.y > -0.5f && currentSwipe.y < 0.5f)
                {
                     //swipe right
                     playerInputAction = rightAction;
                }
            }
        }
    }
#endif

#if UNITY_EDITOR
    public void Swipe()
    {
        if (Input.GetMouseButtonDown(0))
        {
            firstPressPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        }
        if (Input.GetMouseButtonUp(0))
        {
            secondPressPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);

            currentSwipe = new Vector2(secondPressPos.x - firstPressPos.x, secondPressPos.y - firstPressPos.y);

            currentSwipe.Normalize();

            if (currentSwipe.y > 0 && currentSwipe.x > -0.5f && currentSwipe.x < 0.5f)
            {
                Debug.Log("up swipe");
                playerInputAction = upAction;
            }
            //swipe down
            if (currentSwipe.y < 0 && currentSwipe.x > -0.5f && currentSwipe.x < 0.5f)
            {
                Debug.Log("down swipe");
                playerInputAction = downAction;
            }
            //swipe left
            if (currentSwipe.x < 0 && currentSwipe.y > -0.5f && currentSwipe.y < 0.5f)
            {
                Debug.Log("left swipe");
                playerInputAction = leftAction;
            }
            //swipe right
            if (currentSwipe.x > 0 && currentSwipe.y > -0.5f && currentSwipe.y < 0.5f)
            {
                Debug.Log("right swipe");
                playerInputAction = rightAction;
            }
        }
    }
#endif
}
