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
    public Animator anim;
    public Animator arrowAnim;

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
    bool doUpdateArrows;

    void Start()
    {
        takeBackups();
        SwipeTimer = SwipeTime;
        giveNewDirection = true;
        startSwipeTimer = false;
        startingNextPhase = false;
        startIntroTimer = true;
        doUpdateArrows = true;
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
                        giveNewDirection = false;
                    }
                }
                if (SwipeTimer > 0 && startSwipeTimer == true)
                {
                    Swipe();
                    bool tempBool = isCorrectDirection();
                    if (tempBool)
                    {
                        anim.SetTrigger("Punch");
                        Global.Instance.playPunch();
                        power += PowerValue;
                        giveNewDirection = true;
                    }
                }
                updateArrows();
            }
        }
    }

    void LateUpdate()
    {
        if (Global.Instance.gameState == eStates.PowerSwiping)
        {
            if (!startingNextPhase)
            {
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
                    arrowAnim.SetTrigger("None");
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

    void updateArrows()
    {
        if (givenSwipeDir == "Up")
        {
            arrowAnim.SetTrigger("Up");
        }
        if (givenSwipeDir == "Down")
        {
            arrowAnim.SetTrigger("Down");
        }
        if (givenSwipeDir == "Left")
        {
            arrowAnim.SetTrigger("Left");
        }
        if (givenSwipeDir == "Right")
        {
            arrowAnim.SetTrigger("Right");
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
        anim.SetTrigger("Idle");
        doUpdateArrows = true;
    }

    void startNextPhase()
    {
        doUpdateArrows = false;
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

            //swipe up
            if (currentSwipe.y > 0 && currentSwipe.x > -0.5f && currentSwipe.x < 0.5f)
            {
                playerInputAction = upAction;
            }
            //swipe down
            if (currentSwipe.y < 0 && currentSwipe.x > -0.5f && currentSwipe.x < 0.5f)
            {
                playerInputAction = downAction;
            }
            //swipe left
            if (currentSwipe.x < 0 && currentSwipe.y > -0.5f && currentSwipe.y < 0.5f)
            {
                playerInputAction = leftAction;
            }
            //swipe right
            if (currentSwipe.x > 0 && currentSwipe.y > -0.5f && currentSwipe.y < 0.5f)
            {
                playerInputAction = rightAction;
            }
        }
    }
}
