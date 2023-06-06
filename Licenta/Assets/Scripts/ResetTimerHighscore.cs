using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetTimerHighscore : MonoBehaviour
{
    void Start()
    {
        PlayerPrefs.SetInt("timer", 0);
    }
}
