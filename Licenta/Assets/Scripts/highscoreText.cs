using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class highscoreText : MonoBehaviour
{
    public TextMeshProUGUI text;
    private int timer;
    private string message;

    void Start()
    {
        timer = PlayerPrefs.GetInt("timer");
        message = text.text;
        text.text = message.Replace("x", timer.ToString());
    }

}
