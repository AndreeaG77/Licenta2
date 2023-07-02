using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Windows;

public class highscore : MonoBehaviour
{
    public TextMeshProUGUI score1;
    public TextMeshProUGUI score2;
    public TextMeshProUGUI score3;
    private int timer;
    private string playerName;
    private string[] scoreText;
    private int[] scores;
    private List<(int?, string)> tupleList;
    void Start()
    {
        timer = PlayerPrefs.GetInt("timer");
        playerName = PlayerPrefs.GetString("playerName");
        tupleList = new List<(int?, string)>();
        scoreText = new string[] { PlayerPrefs.GetString("name0"), PlayerPrefs.GetString("name1"), PlayerPrefs.GetString("name2") };
        scores = new int[] { PlayerPrefs.GetInt("score0"), PlayerPrefs.GetInt("score1"), PlayerPrefs.GetInt("score2") };

        if (timer != 0)
        {
            RearrangeScore();
        }
    }

    private void RearrangeScore()
    {
        for (int i = 0; i < scores.Length; i++)
        {
            if (scores[i] == 0)
            {
                tupleList.Add((null, scoreText[i]));
            }
            else
            {
                tupleList.Add((scores[i], scoreText[i]));
            }

        }

        tupleList.Add((timer, playerName));

        tupleList.Sort((x, y) =>
        {
            if (x.Item1 == null && y.Item1 == null)
                return 0;
            if (x.Item1 == null)
                return 1;
            if (y.Item1 == null)
                return -1;
            return x.Item1.Value.CompareTo(y.Item1.Value);
        });

        UpdateScore2();
        UpdatePlayerPrefs();
    }

    private void UpdateScore2()
    {
        score1.text = "1. " + tupleList[0].Item2 + " - " + (tupleList[0].Item1 != null ? tupleList[0].Item1.ToString() : "0");
        score2.text = "2. " + tupleList[1].Item2 + " - " + (tupleList[1].Item1 != null ? tupleList[1].Item1.ToString() : "0");
        score3.text = "3. " + tupleList[2].Item2 + " - " + (tupleList[2].Item1 != null ? tupleList[2].Item1.ToString() : "0");
    }

    private void UpdatePlayerPrefs()
    {
        PlayerPrefs.SetString("name0", tupleList[0].Item2);
        PlayerPrefs.SetString("name1", tupleList[1].Item2);
        PlayerPrefs.SetString("name2", tupleList[2].Item2);

        PlayerPrefs.SetInt("score0", tupleList[0].Item1 ?? 0);
        PlayerPrefs.SetInt("score1", tupleList[1].Item1 ?? 0);
        PlayerPrefs.SetInt("score2", tupleList[2].Item1 ?? 0);
    }
}
