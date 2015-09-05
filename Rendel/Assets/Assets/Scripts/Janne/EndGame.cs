using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class EndGame : MonoBehaviour
{
    string name = "";
    string score = "";
    List<Scores> highScore;

    public InputField inputField;
    public GameObject masterScoreSystem;

    private MasterScoreSystem mss;

    public void AddName(string nameInput)
    {
        name = inputField.text;
    }

    public void AddScore()
    {
        score = mss.GetScore().ToString();
        HighScoreManager._instance.SaveHighScore(name, System.Int32.Parse(score));
        highScore = HighScoreManager._instance.GetHighScore();
    }

    public void GetLeaderboard()
    {
        highScore = HighScoreManager._instance.GetHighScore();
    }

    void Awake()
    {
        mss = masterScoreSystem.GetComponent<MasterScoreSystem>();
    }

    //public void Get
}
