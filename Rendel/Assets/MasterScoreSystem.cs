using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class MasterScoreSystem : MonoBehaviour 
{
    public Text scoreText;
    List<GameObject> effects = new List<GameObject>();
    public static MasterScoreSystem Instanse;
    public int poolLenght = 500;

    int currentEffect;
 int currentScore;
   int visibleScore;
    public GameObject scoreEffect;
    public int oneScoreValue = 100;
	// Use this for initialization
    public Rigidbody2D valaMies;
    public Vector3 noste;
	

    public int getScore()
    {

        return visibleScore *100;
    }
    void Awake()
    {
        Instanse = this;
        
    }
    
    void Start () 
    {
	
        for(int i =0 ; i<poolLenght;i++)
        {
            Instantiate(scoreEffect, scoreEffect.transform.position, transform.rotation);
        }

	}
    public void addMeToList(GameObject g)
    {
        effects.Add(g);
    }

    public float masxNosteYvelocity = 20;
    public void setEffect(Vector3 pos)
    {
        effects[currentEffect].transform.position = pos;
        effects[currentEffect].SetActive(true);
        currentEffect++;
        if (currentEffect >= poolLenght)
            currentEffect = 0;
     //   currentScore += oneScoreValue;

        if(valaMies.velocity.y < masxNosteYvelocity)
        valaMies.AddForce(noste,ForceMode2D.Impulse);

    }

    void Update()
    {


        if (Global.Instance.gameState != eStates.Endgame)
        {
            //      visibleScore = (int)Mathf.Lerp(visibleScore, currentScore, Time.deltaTime * lerpSpeed);
            visibleScore = (int)valaMies.transform.position.x - 5;

        }
        scoreText.text =(100* visibleScore).ToString();
    }
    public float lerpSpeed = 4;





}
