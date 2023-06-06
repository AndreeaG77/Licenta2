using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class damage : MonoBehaviour
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
    private healthBar healthScript;

    private bool isGuarding;

    public AudioSource source;
    public AudioClip clip;

    private void Start()
    {
        player = GameObject.FindWithTag("player1");
        animator = player.GetComponent<Animator>();
        healthBarI = GameObject.FindWithTag("life1").GetComponent<Image>();
        healthScript = healthBarI.GetComponent<healthBar>();
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Y))
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
        int damage = isGuarding ? guardedPunchDamage : punchDamage;
        DealDamage(damage, isGuarding);
    }

    public void Kick()
    {
        int damage = isGuarding ? guardedKickDamage : kickDamage;
        DealDamage(damage, isGuarding);
    }

    public void Combo()
    {
        int damage = isGuarding ? guardedComboDamage : comboDamage;
        DealDamage(damage, isGuarding);
    }

    public void DealDamage(int damage, bool guard)
    {
        player = GameObject.FindWithTag("player1");
        animator = player.GetComponent<Animator>();
        healthBarI = GameObject.FindWithTag("life1").GetComponent<Image>();
        healthScript = healthBarI.GetComponent<healthBar>();
        healthScript.health -= damage;
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