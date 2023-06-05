using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class CPUDamage : MonoBehaviour
{
    public int punchDamage = 10;
    public int kickDamage = 20;
    public int comboDamage = 30;

    private Animator animator;
    private Image healthBarI;
    private healthBar2 healthScript;

    private void Start()
    {
        animator = GetComponent<Animator>();
        healthBarI = GameObject.FindWithTag("life2").GetComponent<Image>();
        healthScript = healthBarI.GetComponent<healthBar2>();
    }

    public void Punch()
    {
        DealDamage(punchDamage);
    }

    public void Kick()
    {
        DealDamage(kickDamage);
    }

    public void Combo()
    {
        DealDamage(comboDamage);
    }

    public void DealDamage(int damage)
    {
        healthScript.health2 -= damage;
        
            if (animator != null)
            {
                animator.SetTrigger("hit");
            }

    }

}