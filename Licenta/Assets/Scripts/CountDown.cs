using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CountDown : MonoBehaviour
{
    float currentTime = 0f;
    float startingTime = 60f;
    public TextMeshProUGUI countdown;

    void Start()
    {
        currentTime = startingTime;
    }


    void Update()
    {
        currentTime -= 1 * Time.deltaTime;
        countdown.text = currentTime.ToString("0");

        if(currentTime <= 0) 
        {
            currentTime = 0;
        }
        if(currentTime <= 10)
        {
            countdown.color = Color.red;
        }
    }
}
