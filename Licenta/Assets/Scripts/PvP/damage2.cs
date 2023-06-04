using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class damage2 : MonoBehaviour
{
    public int punchDamage = 10;
    public int kickDamage = 20;
    public int comboDamage = 30;

    public int guardedPunchDamage = 5;
    public int guardedKickDamage = 10;
    public int guardedComboDamage = 15;

    private Animator animator;
    private Image healthBarI;
    private healthBar2 healthScript;

    private bool isGuarding;

    private void Start()
    {
        animator = GetComponent<Animator>();
        healthBarI = GameObject.FindWithTag("life2").GetComponent<Image>();
        healthScript = healthBarI.GetComponent<healthBar2>();
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.I))
        {
            isGuarding = true;
            //Debug.Log("garda");
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
        DealDamage2(damage, isGuarding);
    }

    public void Kick()
    {
        int damage = isGuarding ? guardedKickDamage : kickDamage;
        DealDamage2(damage, isGuarding);
    }

    public void Combo()
    {
        int damage = isGuarding ? guardedComboDamage : comboDamage;
        DealDamage2(damage, isGuarding);
    }

    public void DealDamage2(int damage, bool guard)
    {
        healthScript.health2 -= damage;
        if (guard)
        {
            if (animator != null)
            {
                Debug.Log("xx");
                //animator.SetBool("blockhitB", true);
                //animator.SetBool("block1", false);
                animator.SetTrigger("blockhitT");
                //yield return new WaitForSeconds(3f);
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

    }

}