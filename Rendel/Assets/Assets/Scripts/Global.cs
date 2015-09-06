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


 public Canvas highscoreCanvas;

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
	
    public void setWorldState(eStates state)
    {
        if (state == eStates.PowerSwiping)
        {
            powerSwiping();
            playPowerUp();
            valamies.isKinematic = true;
        }
        if (state == eStates.AngleSwiping)
        {
            valamies.isKinematic = true;
        }

        if (state == eStates.Flying)
        {
            playPunch();
            Invoke("D", 1);
        }

        if (state == eStates.Endgame)
        {
            playPunch();
            highscoreCanvas.enabled = true;
    
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
