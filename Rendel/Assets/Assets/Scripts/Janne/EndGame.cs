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
    public Canvas leaderboardCanvas;

    public GameObject[] allHighScoreNames;
    public GameObject[] allHighScoreScores;

    private MasterScoreSystem mss;
    private Canvas hsc;
    private Canvas lbc;

    private bool loadHighscores;

    public void AddName(string nameInput)
    {
        name = inputField.text;
    }

    public void AddScore()
    {
        score = mss.getScore();
        print(name + score);
        HighScoreManager2._instance.SaveHighScore(name, score);
        hsc.enabled = false;
        lbc.enabled = true;
        loadHighscores = true;
        GetLeaderboard();
    }

    public void GetLeaderboard()
    {
        highScore = HighScoreManager2._instance.GetHighScore();
    }

    public void LoadMainMenu()
    {
        Application.LoadLevel("MainMenu");
    }

    void Awake()
    {
        loadHighscores = false;
        mss = masterScoreSystem.GetComponent<MasterScoreSystem>();
        hsc = highScoreCanvas.GetComponent<Canvas>();
        lbc = leaderboardCanvas.GetComponent<Canvas>();
    }

    void Start()
    {
        loadHighscores = false;
        highScore = new List<Scores>();
    }

    void Update()
    {
        if (Global.Instance.gameState == eStates.Endgame)
        {
            if (loadHighscores)
            {
                foreach (Scores _score in highScore)
                {
                    int i = 0;
                    Text tempName = allHighScoreNames[i].GetComponent<Text>();
                    tempName.text = "Name: " + _score.name;
                    Text tempScore = allHighScoreScores[i].GetComponent<Text>();
                    tempScore.text = "Score: " + _score.score.ToString();
                }
            }
        }
        else
        {
            hsc.enabled = false;
        }
    }
}
