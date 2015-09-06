using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Global : MonoBehaviour 
{
    GameObject scriptHolder;
    PowerSwipe1 pw;

    private static Global instance;
    public static Global Instance 
    {
        get { return instance; }
    }
    public eStates gameState;
    GameObject explosion;

    public AudioClip punch;
    public AudioClip powerUp;
    public AudioClip scream;

    AudioSource _audioSource;
 public   Rigidbody2D valamies;
 public int numberOfRounds;
 public int currentRound;

 public Animator valamansAnimator;
 public GameObject highscoreCanvas;
 public Text finalSCOREtext;

 public MasterScoreSystem mss;

	void Awake ()
    {
        _audioSource = GetComponent<AudioSource>();
        scriptHolder = GameObject.Find("ScriptHolder");
        pw = scriptHolder.GetComponent<PowerSwipe1>();

        if (instance != this && instance == null)
        {  
            instance = this;
        }
        else Destroy(gameObject);

        explosion = GameObject.Find("Explosion");
	}
	
    public void resetScene()
    {
        Application.LoadLevel(Application.loadedLevel);
    }
    public void setWorldState(eStates state)
    {
        if (state == eStates.PowerSwiping)
        {
            valamansAnimator.SetTrigger("Idle");
            powerSwiping();
            playPowerUp();
            valamies.isKinematic = true;
        }
        if (state == eStates.AngleSwiping)
        {
            valamansAnimator.SetTrigger("Idle");
            valamies.isKinematic = true;
        }

        if (state == eStates.Flying)
        {
            Invoke("D", 1);
            print("Flying");
        }

        if (state == eStates.Endgame)
        {
        //   _audioSource.clip = scream;
              _audioSource.Play();
              highscoreCanvas.SetActive(true);
            finalSCOREtext.text = mss.getScore().ToString();
        }

        gameState = state;
    }


    void D()
    {
        playScream();

    }

    public void playPunch()
    {
        _audioSource.clip = punch;
        _audioSource.Play();
        valamansAnimator.SetTrigger("Hit");

    }
    public void playPowerUp()
    {
        _audioSource.clip = powerUp;
        _audioSource.Play();
    }

    public void playScream()
    {
        _audioSource.clip = scream;
        _audioSource.Play();
        valamansAnimator.SetTrigger("Fly");
    }


    public void setExplosion(Vector3 pos)
    {
        explosion.transform.position = pos;
        explosion.SetActive(true);
    }

    public float totalForce;

    void powerSwiping()
    {
        pw.resetCurrentState();
    }
}
