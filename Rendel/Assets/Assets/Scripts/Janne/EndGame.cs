using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class EndGame : MonoBehaviour
{
    string name = "name";
    int score = 0;
    List<Scores> highScore;

    public InputField inputField;
    public GameObject masterScoreSystem;
    public Canvas highScoreCanvas;
  
    private MasterScoreSystem mss;
    private Canvas hsc;



    public void AddName(string nameInput)
    {
        name = inputField.text;
    }

    public void AddScore()
    {
        score = mss.GetScore();
        print(score);
        HighScoreManager2._instance.SaveHighScore(name, score);
        //highScore = HighScoreManager._instance.GetHighScore();
    }

    public void GetLeaderboard()
    {
        highScore = HighScoreManager2._instance.GetHighScore();
    }

    void Awake()
    {
        mss = masterScoreSystem.GetComponent<MasterScoreSystem>();
        hsc = highScoreCanvas.GetComponent<Canvas>();
    }

    void Start()
    {
        highScore = new List<Scores>();
    }

    void Update()
    {
        if (Global.Instance.gameState == eStates.Endgame)
        {
            hsc.enabled = true;
        }
        else
        {
            hsc.enabled = false;
        }
    }
}
