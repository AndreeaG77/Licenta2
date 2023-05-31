using System.Collections;
using UnityEngine;

public class damage : MonoBehaviour
{
    public int punchDamage = 10;
    public int kickDamage = 20;
    public int comboDamage = 30;

    public int guardedPunchDamage = 5;
    public int guardedKickDamage = 10;
    public int guardedComboDamage = 15;

    private Animator animator;

    private bool isGuarding;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.I) || Input.GetKey(KeyCode.Y))
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
        StartCoroutine(DealDamage(damage, isGuarding));
    }

    public void Kick()
    {
        int damage = isGuarding ? guardedKickDamage : kickDamage;
        StartCoroutine(DealDamage(damage, isGuarding));
    }

    public void Combo()
    {
        int damage = isGuarding ? guardedComboDamage : comboDamage;
        StartCoroutine(DealDamage(damage, isGuarding));
    }

    IEnumerator DealDamage(int damage, bool guard)
    {
        if(guard)
        {
            if (animator != null)
            {
                //Debug.Log("xx");
                animator.SetBool("blockhitB", true);
                //animator.SetBool("block1", false);
                //animator.SetTrigger("hit");
                yield return new WaitForSeconds(1f);
                //yield return null;
                animator.SetBool("blockhitB", false);
                //animator.SetBool("block1", true);
            }
        }
        else
        {
            if (animator != null)
            {
                animator.SetBool("hitB", true);
                //animator.SetTrigger("hit");
                yield return new WaitForSeconds(2.5f);
                //yield return null;
                animator.SetBool("hitB", false);
            }
        }
        
    }

}