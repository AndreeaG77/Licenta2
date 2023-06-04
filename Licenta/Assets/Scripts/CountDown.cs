using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CountDown : MonoBehaviour
{
    float currentTime = 0f;
    float startingTime = 10f;
    public TextMeshProUGUI countdown;
    private bool isPaused = false;

    void Start()
    {
        currentTime = startingTime;
    }


    void Update()
    {
        if (!isPaused)
        {
            currentTime -= 1 * Time.deltaTime;
            countdown.text = currentTime.ToString("0");

            if(currentTime <= 0) 
            {
                currentTime = 0;
                StartCoroutine(resetCountdown());
            }
            if(currentTime <= 10)
            {
                countdown.color = Color.red;
            }
        }
        
    }

    public IEnumerator resetCountdown()
    {
        yield return new WaitForSeconds(2f);
         currentTime = startingTime;
    }

    public void resetCountdown2()
    {
        //yield return new WaitForSeconds(3f);
        currentTime = startingTime;
        countdown.color = Color.black;
    }
    public void PauseCountdown()
    {
        isPaused = true;
    }

    public void ResumeCountdown()
    {
        isPaused = false;
    }
    /*public void resumeCountdown()
    {

    }*/
}
