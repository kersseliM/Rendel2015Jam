using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EndGame : MonoBehaviour
{
    string name = "";
    string score = "";
    List<Scores> highScore;

    void Start()
    {

    }

    public void AddScore()
    {
        HighScoreManager._instance.SaveHighScore(name, System.Int32.Parse(score));
        highScore = HighScoreManager._instance.GetHighScore();
    }

    public void GetLeaderboard()
    {
        highScore = HighScoreManager._instance.GetHighScore();
    }

    public void Get
}
