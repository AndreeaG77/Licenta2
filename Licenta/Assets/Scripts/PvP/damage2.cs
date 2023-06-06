using System.Collections;
using UnityEngine;
using UnityEngine.TextCore.Text;
using UnityEngine.UI;

public class damage2 : MonoBehaviour
{
    public int punchDamage = 10;
    public int kickDamage = 20;
    public int comboDamage = 30;

    public int guardedPunchDamage = 5;
    public int guardedKickDamage = 10;
    public int guardedComboDamage = 15;

    private GameObject player;
    private Animator animator;
    private Image healthBarI;
    private healthBar2 healthScript;

    private int damage;

    private bool isGuarding;

    public AudioSource source;
    public AudioClip clip;

    private void Start()
    {
        player = GameObject.FindWithTag("player2");
        animator = player.GetComponent<Animator>();
        healthBarI = GameObject.FindWithTag("life2").GetComponent<Image>();
        healthScript = healthBarI.GetComponent<healthBar2>();
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.I))
        {
            isGuarding = true;
        }
        else
        {
            isGuarding = false;
        }
    }

    public void Punch()
    {
        damage = isGuarding ? guardedPunchDamage : punchDamage;
        DealDamage2(damage, isGuarding);
    }

    public void Kick()
    {
        damage = isGuarding ? guardedKickDamage : kickDamage;
        DealDamage2(damage, isGuarding);
    }

    public void Combo()
    {
        damage = isGuarding ? guardedComboDamage : comboDamage;
        DealDamage2(damage, isGuarding);
    }

    public void DealDamage2(int damage, bool guard)
    {
        player = GameObject.FindWithTag("player2");
        animator = player.GetComponent<Animator>();
        healthBarI = GameObject.FindWithTag("life2").GetComponent<Image>();
        healthScript = healthBarI.GetComponent<healthBar2>();
        healthScript.health2 -= damage;
        if (guard)
        {
            if (animator != null)
            {
                source.clip = clip;
                source.PlayOneShot(source.clip);
                animator.SetTrigger("blockhitT");
            }
        }
        else
        {
            if (animator != null)
            {
                source.clip = clip;
                source.PlayOneShot(source.clip);
                animator.SetTrigger("hit");
            }
        }

    }

}