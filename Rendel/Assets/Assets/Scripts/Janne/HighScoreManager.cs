//using UnityEngine;
//using System.Collections;
//using System.Collections.Generic;

//public class HighScoreManager : MonoBehaviour
//{
//    private static HighScoreManager m_instance;
//    private const int LeaderBoardLength = 10;

//    public static HighScoreManager _instance
//    {
//        get
//        {
//            if (m_instance == null)
//            {
//                m_instance = new GameObject("HighScoreManager").AddComponent<HighScoreManager>();
//            }
//            return m_instance;
//        }
//    }

//    void Awake()
//    {
//        if (_instance == null)
//        {
//            m_instance = this;
//        }
//        else if (m_instance != this)
//        {
//            Destroy(gameObject);
//        }
//        DontDestroyOnLoad(gameObject);
//    }

//    public void SaveHighScore(string name, int score)
//    {
//        print("highScore");
//        List<Scores> HighScores = new List<Scores>();

//        int i = 1;

//        while (i <= LeaderBoardLength && PlayerPrefs.HasKey("HighScore" + i + "score"))
//        {
//            Scores temp = new Scores();
//            temp.score = PlayerPrefs.GetInt("HighScore" + i + "score");
//            temp.name = PlayerPrefs.GetString("HighScore" + i + "name");
//            HighScores.Add(temp);
//            i++;
//        }
//        if (HighScores.Count == 0)
//        {
//            Scores _temp = new Scores();
//            _temp.name = name;
//            _temp.score = score;
//            HighScores.Add(_temp);
//        }
//        else
//        {
//            for (i = 1; i <= HighScores.Count && i <= LeaderBoardLength; i++)
//            {
//                if (score > HighScores[i - 1].score)
//                {
//                    Scores _temp = new Scores();
//                    _temp.name = name;
//                    _temp.score = score;
//                    HighScores.Insert(i - 1, _temp);
//                    break;
//                }
//                if (i == HighScores.Count && i < LeaderBoardLength)
//                {
//                    Scores _temp = new Scores();
//                    _temp.name = name;
//                    _temp.score = score;
//                    HighScores.Add(_temp);
//                    break;
//                }
//            }
//        }

//        i = 1;
//        while (i <= LeaderBoardLength && i <= HighScores.Count)
//        {
//            PlayerPrefs.SetString("HighScore" + i + "name", HighScores[i + i].name);
//            PlayerPrefs.SetInt("HighScore" + i + "name", HighScores[i + i].score);
//            i++;
//        }
//    }

//    public List<Scores> GetHighScore()
//    {
//        List<Scores> HighScores = new List<Scores>();

//        int i = 1;
//        while (i <= LeaderBoardLength && PlayerPrefs.HasKey("HighScore" + i + "score"))
//        {
//            Scores temp = new Scores();
//            temp.score = PlayerPrefs.GetInt("HighScore" + "score");
//            temp.name = PlayerPrefs.GetString("HighScore" + "score");
//            HighScores.Add(temp);
//            i++;
//        }

//        return HighScores;
//    }

//    void OnApplicationQuit()
//    {
//        PlayerPrefs.Save();
//    }
//}
//public class Scores
//{
//    public int score;
//    public string name;

//}