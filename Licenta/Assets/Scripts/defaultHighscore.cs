using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class defaultHighscore : MonoBehaviour
{
    void Start()
    {
        PlayerPrefs.SetString("name0", "None");
        PlayerPrefs.SetString("name1", "None");
        PlayerPrefs.SetString("name2", "None");

        PlayerPrefs.SetInt("score0", 0);
        PlayerPrefs.SetInt("score1", 0);
        PlayerPrefs.SetInt("score2", 0);

        PlayerPrefs.SetString("playerName", "None");
        PlayerPrefs.SetInt("timer", 0);
    }
}
