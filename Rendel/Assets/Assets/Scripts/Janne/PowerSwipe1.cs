using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PowerSwipe1 : MonoBehaviour
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

    //Test timers
    public Text testTimerIntro;
    public Text testTimerSwipeTime;
    public Text testTimerNextScene;

    //Timer values
    public float IntroDelay = 4;
    public float SwipeTime = 5;
    public int PowerValue = 5;
    public float StartingNextPhaseDelay = 3;

    //Timers
    float SwipeTimer;
    float gameTime;
    float randomizer;

    //Backup values
    float swipeTimeBackup;
    float introDelayBackup;
    int powerValueBackup;
    float startingNextPhaseDelayBackup;

    //Input handling
    int currentAction;
    string playerInputAction = " ";
    string upAction = "Up";
    string downAction = "Down";
    string leftAction = "Left";
    string rightAction = "Right";
    SwipeDirection randomSwipeDir;
    string givenSwipeDir;
    bool giveNewDirection;
    bool startSwipeTimer;
    bool startIntroTimer;

    //Statistics
    int power;
    int points;

    //Next phase
    bool startingNextPhase;

    void Start()
    {
        takeBackups();
        SwipeTimer = SwipeTime;
        giveNewDirection = true;
        startSwipeTimer = false;
        startingNextPhase = false;
        startIntroTimer = true;
    }

    void Update()
    {
        if (Global.Instance.gameState == eStates.PowerSwiping)
        {
            if (!startingNextPhase)
            {
                updateTimers();
                showReadyGo(IntroDelay);
                if (gameTime > IntroDelay)
                {
                    startSwipeTimer = true;
                    startIntroTimer = false;
                    if (giveNewDirection == true)
                    {
                        randomSwipeDir = getRandomEnum<SwipeDirection>();
                        givenSwipeDir = randomSwipeDir.ToString();
                        print(givenSwipeDir);
                        Direction.text = givenSwipeDir;
                        giveNewDirection = false;
                    }
                }
                if (SwipeTimer > 0 && startSwipeTimer == true)
                {
                    Swipe();
                    bool tempBool = isCorrectDirection();
                    if (tempBool)
                    {
                        power += PowerValue;
                        giveNewDirection = true;
                    }
                }
            }
        }
    }

    void LateUpdate()
    {
        if (Global.Instance.gameState == eStates.PowerSwiping)
        {
            if (!startingNextPhase)
            {
                ///COUNTDOWN HERE
                showCountDown(SwipeTimer);
                PowerText.text = power.ToString();
                if (SwipeTimer <= 0)
                {
                    startNextPhase();
                }
            }
            if (startingNextPhase)
            {
                StartingNextPhaseDelay -= 1 * Time.deltaTime;

                if (StartingNextPhaseDelay <= 0)
                    StartingNextPhaseDelay = 0;
                if (StartingNextPhaseDelay <= 0)
                {
                    Global.Instance.setWorldState(eStates.AngleSwiping);
                    Global.Instance.totalForce = power;
                }
            }
        }
        testTimerIntro.text = "INTRO: " + IntroDelay.ToString();
        testTimerSwipeTime.text = "SWIPETIME:" + SwipeTimer.ToString();
        testTimerNextScene.text = "NEXTSCENE:" + StartingNextPhaseDelay.ToString();
    }

    void showReadyGo(float timer)
    {
        //print("CALLED READY_GO");
        if (timer > 1)
        {
            InfoText.text = "READY";
        }
        if (timer <= 1 && timer > 0)
        {
            InfoText.text = "GO";
        }
        if (timer >= 0)
        {
            InfoText.text = "";
        }
    }

    void takeBackups()
    {
        swipeTimeBackup = SwipeTime;
        introDelayBackup = IntroDelay;
        powerValueBackup = PowerValue;
        startingNextPhaseDelayBackup = StartingNextPhaseDelay;
    }

    void updateTimers()
    {
        if (startSwipeTimer)
        {
            SwipeTimer -= 1 * Time.deltaTime;
        }
        if (startIntroTimer)
        {
            IntroDelay -= 1 * Time.deltaTime;
        }
        if (SwipeTimer <= 0)
        {
            SwipeTimer = 0;
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
    public void resetCurrentState()
    {
        print("Power Swipe Reset");
        SwipeTimer = swipeTimeBackup;
        IntroDelay = introDelayBackup;
        PowerValue = powerValueBackup;
        gameTime = 0;
        startSwipeTimer = false;
        giveNewDirection = false;
        giveNewDirection = true;
        startIntroTimer = true;
        startingNextPhase = false;
    }

    void startNextPhase()
    {
        Direction.text = "";
        timeLeftText.text = "";
        startingNextPhase = true;
    }

    void showCountDown(float timer)
    {
        timeLeftText.text = Mathf.Round(timer).ToString();
    }

    static T getRandomEnum<T>()
    {
        System.Array arr = System.Enum.GetValues(typeof(T));
        T randomValue = (T)arr.GetValue(UnityEngine.Random.Range(0, arr.Length));
        return randomValue;
    }
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
}
