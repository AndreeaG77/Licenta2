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
    private string auxName1;
    private int auxScore1;
    private string auxName2;
    private int auxScore2;
    void Start()
    {
        timer = PlayerPrefs.GetInt("timer");
        playerName = PlayerPrefs.GetString("playerName");
        scoreText = new string[] { PlayerPrefs.GetString("name0"), PlayerPrefs.GetString("name1"), PlayerPrefs.GetString("name2") };
        scores = new int[] { PlayerPrefs.GetInt("score0"), PlayerPrefs.GetInt("score1"), PlayerPrefs.GetInt("score2") };
        UpdateScore();
    }

    private void UpdateScore()
    {
        if(timer == 0)
        {
            score1.text = "1. " + scoreText[0] + " - " + scores[0].ToString();
            score2.text = "2. " + scoreText[1] + " - " + scores[1].ToString();
            score3.text = "3. " + scoreText[2] + " - " + scores[2].ToString();
        }

        else
        {
            for(int i=0; i<scores.Length; i++)
            {
                if (scores[i] == 0 && i == 0)
                {
                    score1.text = $"{i+1}" + ". " + playerName + " - " + timer.ToString();
                    PlayerPrefs.SetString("name0", playerName);
                    PlayerPrefs.SetInt("score0", timer);
                    score2.text = "2. " + scoreText[1] + " - " + scores[1].ToString();
                    score3.text = "3. " + scoreText[2] + " - " + scores[2].ToString();
                    break;
                }
                else
                {
                    if(timer < scores[i])
                    {
                        auxName1 = scoreText[i];
                        auxScore1 = scores[i];
                        string currentScore = "score" + $"{i}";
                        string currentName = "name" + $"{i}";
                        PlayerPrefs.SetInt(currentScore, timer);
                        PlayerPrefs.SetString(currentName, playerName);
                        i++;
                        while (i< scores.Length)
                        {
                            auxName2 = scoreText[i];
                            auxScore2 = scores[i];
                            currentScore = "score" + $"{i}";
                            currentName = "name" + $"{i}";
                            PlayerPrefs.SetInt(currentScore, auxScore1);
                            PlayerPrefs.SetString(currentName, auxName1);
                            auxName1 = auxName2;
                            auxScore1 = auxScore2;
                            i++;
                        }
                        score1.text = "1. " + PlayerPrefs.GetString("name0") + " - " + PlayerPrefs.GetInt("score0").ToString();
                        score2.text = "2. " + PlayerPrefs.GetString("name1") + " - " + PlayerPrefs.GetInt("score1").ToString();
                        score3.text = "3. " + PlayerPrefs.GetString("name2") + " - " + PlayerPrefs.GetInt("score2").ToString();

                    }

                    
                }
            }
        }
    }
}
