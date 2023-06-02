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

    private Animator animator;
    private Image healthBarI;
    private healthBar healthScript;
    //private GameObject scoreManagement;

    private bool isGuarding;

    private void Start()
    {
        animator = GetComponent<Animator>();
        healthBarI = GameObject.FindWithTag("life1").GetComponent<Image>();
        healthScript = healthBarI.GetComponent<healthBar>();
       // scoreManagement = GameObject.Find("ScoreManagement");
        //ScoreManagement sm = scoreManagement.GetComponent<ScoreManagement>();
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

    public void SetGuard(bool isGuarding)
    {
        this.isGuarding = isGuarding;
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
        healthScript.health -= damage;
        //Debug.Log("1111");
        if (guard)
        {
            if (animator != null)
            {
                //Debug.Log("xx");
                //animator.SetBool("blockhitB", true);
                //animator.SetBool("block1", false);
                //animator.SetTrigger("hit");
                //yield return new WaitForSeconds(2f);
                animator.SetTrigger("blockhitT");
                //yield return null;
                //animator.SetBool("blockhitB", false);
                //animator.SetBool("block1", true);
            }
        }
        else
        {
            if (animator != null)
            {
                //animator.SetBool("hitB", true);
                animator.SetTrigger("hit");
                //yield return new WaitForSeconds(2f);
                //yield return null;
                //animator.SetBool("hitB", false);
            }
        }

        //checkDeath();
        
    }

  /*  public void checkDeath()
    {
        if(healthScript.health <= 0)
        {
            sm.endRound();
        }
    }*/

}