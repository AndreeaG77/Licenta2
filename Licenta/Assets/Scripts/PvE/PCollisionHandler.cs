using System.Collections;
using UnityEngine;

public class PCollisionHandler : MonoBehaviour
{

    private MeshRenderer meshRenderer;
    private float collisionCooldown = 0f;
    private float cooldownDuration = 0f;
    private CPUScript enemyScript;
    private GameObject enemy;
    private GameObject characterA;
    private bool alreadyAttacked;
    private damage damageA;
    private Animator animatorA;

    private void Start()
    {
        enemy = GameObject.FindWithTag("player2");
        characterA = GameObject.FindWithTag("player1");
        enemyScript = enemy.GetComponent<CPUScript>();
        damage damageA = characterA.GetComponent<damage>();
        animatorA = characterA.GetComponent<Animator>();
    }
    private void Update()
    {
        if (collisionCooldown > 0f)
        {
            collisionCooldown -= Time.deltaTime;
        }

        if (enemyScript.randomAttack == 2 && !alreadyAttacked)
        {
            alreadyAttacked = true;;
            if (enemy.name == "Sorceron(Clone)")
            {
                if (damageA != null)
                {
                    StartCoroutine(spellDamage(damageA));
                }
            }
        }
    }

    IEnumerator spellDamage(damage damageA)
    {
        yield return new WaitForSeconds(1.6f);
        damageA.Combo();
        alreadyAttacked = false;
    }

    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.CompareTag("bullet"))
        {
            if (damageA != null)
            {
                damageA.Punch();
            }

        }

        if (collisionCooldown > 0f)
        {
            return;
        }

        if (collision.gameObject.CompareTag("player2"))
        {
            //Debug.Log("enter");
            GameObject characterB = collision.gameObject;
            Animator animatorB = characterB.GetComponent<Animator>();

            if (animatorA != null && animatorB != null)
            {
                AnimatorStateInfo stateInfoA = animatorA.GetCurrentAnimatorStateInfo(0);
                AnimatorStateInfo stateInfoB = animatorB.GetCurrentAnimatorStateInfo(0);

                if ((stateInfoA.IsName("idle") || stateInfoA.IsName("walk") || stateInfoA.IsName("backwalk") || stateInfoA.IsName("block")) && stateInfoB.IsName("punch"))
                {
                    if (damageA != null)
                    {
                        damageA.Punch();
                    }
                }

                if ((stateInfoA.IsName("idle") || stateInfoA.IsName("walk") || stateInfoA.IsName("backwalk") || stateInfoA.IsName("block")) && stateInfoB.IsName("kick"))
                {
                    if (damageA != null)
                    {
                        damageA.Kick();
                    }
                }

                if ((stateInfoA.IsName("idle") || stateInfoA.IsName("walk") || stateInfoA.IsName("backwalk") || stateInfoA.IsName("block")) && stateInfoB.IsName("combo"))
                {
                    if (damageA != null)
                    {
                        damageA.Combo();
                    }
                }

            }

        }

        collisionCooldown = cooldownDuration;
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collisionCooldown > 0f)
        {
            return;
        }

        if (collision.gameObject.CompareTag("player2"))
        {
            //Debug.Log("stay");
            GameObject characterB = collision.gameObject;
            Animator animatorB = characterB.GetComponent<Animator>();

            if (animatorA != null && animatorB != null)
            {
                //Debug.Log("stayanim");
                AnimatorStateInfo stateInfoA = animatorA.GetCurrentAnimatorStateInfo(0);
                AnimatorStateInfo stateInfoB = animatorB.GetCurrentAnimatorStateInfo(0);
                AnimatorClipInfo[] clipInfoArray = animatorB.GetCurrentAnimatorClipInfo(0);
                string nume = clipInfoArray[0].clip.name;

                //Debug.Log(stateInfoA.IsName("idle"));
                Debug.Log(nume);

                if ((stateInfoA.IsName("idle") || stateInfoA.IsName("walk") || stateInfoA.IsName("backwalk") || stateInfoA.IsName("block")) && stateInfoB.IsName("punch"))
                {
                    //if (damageA != null)
                    //{
                    Debug.Log("punch");
                    damageA.Punch();
                   // }
                }

                if ((stateInfoA.IsName("idle") || stateInfoA.IsName("walk") || stateInfoA.IsName("backwalk") || stateInfoA.IsName("block")) && stateInfoB.IsName("kick"))
                {
                    //if (damageA != null)
                    //{
                    Debug.Log("kick");
                    damageA.Kick();
                   // }
                }

               /* if ((stateInfoA.IsName("idle") || stateInfoA.IsName("walk") || stateInfoA.IsName("backwalk") || stateInfoA.IsName("block")) && stateInfoB.IsName("combo"))
                {
                    //if (damageA != null)
                    //{
                    Debug.Log("combo");
                    damageA.Combo();
                   // }
                }*/

            }

        }

        collisionCooldown = cooldownDuration;
    }
}
