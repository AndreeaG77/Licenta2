using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class healthBar2 : MonoBehaviour
{
    public const float MAX_HEALTH = 100f;
    public float health2 = MAX_HEALTH;
    private Image healthBarI;
    void Start()
    {
        healthBarI = GetComponent<Image>();
    }

    void Update()
    {
        healthBarI.fillAmount = health2 / MAX_HEALTH;
    }
}
