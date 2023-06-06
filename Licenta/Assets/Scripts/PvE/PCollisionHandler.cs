using System.Collections;
using UnityEngine;

public class PCollisionHandler : MonoBehaviour
{

    private MeshRenderer meshRenderer;
    private float collisionCooldown = 0f;
    private float cooldownDuration = 0.5f;
    private CPUScript enemyScript;
    private GameObject enemy;
    private GameObject characterA;
    private bool alreadyAttacked;
    private damage damageA;
    private Animator animatorA;
    private CPUDamage damageB;

    private void Start()
    {
        enemy = GameObject.FindWithTag("player2");
        enemyScript = enemy.GetComponent<CPUScript>();
        characterA = GameObject.FindWithTag("player1");
        damageA = characterA.GetComponent<damage>();
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
            alreadyAttacked = true;
            if (enemy.name == "Sorceron(Clone)")
            {
                characterA = GameObject.FindWithTag("player1");
                damageA = characterA.GetComponent<damage>();
                animatorA = characterA.GetComponent<Animator>();
                StartCoroutine(spellDamage(damageA));
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
            characterA = GameObject.FindWithTag("player1");
            damageA = characterA.GetComponent<damage>();
            animatorA = characterA.GetComponent<Animator>();
            damageA.Punch();

        }

        if (collisionCooldown > 0f)
        {
            return;
        }

        if (collision.gameObject.CompareTag("player2"))
        {
            GameObject characterB = collision.gameObject;
            Animator animatorB = characterB.GetComponent<Animator>();
            damageB = characterB.GetComponent<CPUDamage>();
            characterA = GameObject.FindWithTag("player1");
            damageA = characterA.GetComponent<damage>();
            animatorA = characterA.GetComponent<Animator>();

            if (animatorA != null && animatorB != null)
            {
                AnimatorStateInfo stateInfoA = animatorA.GetCurrentAnimatorStateInfo(0);
                AnimatorStateInfo stateInfoB = animatorB.GetCurrentAnimatorStateInfo(0);

                if ((stateInfoA.IsName("idle") || stateInfoA.IsName("walk") || stateInfoA.IsName("backwalk") || stateInfoA.IsName("block")) && stateInfoB.IsName("punch"))
                {
                    damageA.Punch();
                }

                if ((stateInfoA.IsName("idle") || stateInfoA.IsName("walk") || stateInfoA.IsName("backwalk") || stateInfoA.IsName("block")) && stateInfoB.IsName("kick"))
                {
                    damageA.Kick();
                }

                if ((stateInfoA.IsName("idle") || stateInfoA.IsName("walk") || stateInfoA.IsName("backwalk") || stateInfoA.IsName("block")) && stateInfoB.IsName("combo"))
                {
                    damageA.Combo();
                }

                if ((stateInfoA.IsName("punch") || stateInfoA.IsName("kick") || stateInfoA.IsName("combo")) && (stateInfoB.IsName("punch") || stateInfoB.IsName("kick") || stateInfoB.IsName("combo")))
                {
                    int randomNumber = Random.Range(1, 3);
                    if (randomNumber == 1)
                    {
                        if (stateInfoB.IsName("punch"))
                        {
                            damageA.Punch();
                        }
                        if (stateInfoB.IsName("kick"))
                        {
                            damageA.Kick();
                        }
                        if (stateInfoB.IsName("combo"))
                        {
                            damageA.Combo();
                        }
                    }
                    else
                    {
                        if (stateInfoA.IsName("punch"))
                        {
                            damageB.Punch();
                        }
                        if (stateInfoA.IsName("kick"))
                        {
                            damageB.Kick();
                        }
                        if (stateInfoA.IsName("combo"))
                        {
                            damageB.Combo();
                        }
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
            GameObject characterB = collision.gameObject;
            Animator animatorB = characterB.GetComponent<Animator>();
            damageB = characterB.GetComponent<CPUDamage>();
            characterA = GameObject.FindWithTag("player1");
            damageA = characterA.GetComponent<damage>();
            animatorA = characterA.GetComponent<Animator>();

            if (animatorA != null && animatorB != null)
            {

                AnimatorStateInfo stateInfoA = animatorA.GetCurrentAnimatorStateInfo(0);
                AnimatorStateInfo stateInfoB = animatorB.GetCurrentAnimatorStateInfo(0);

                if ((stateInfoA.IsName("idle") || stateInfoA.IsName("walk") || stateInfoA.IsName("backwalk") || stateInfoA.IsName("block")) && stateInfoB.IsName("punch"))
                {
                    damageA.Punch();
                }

                if ((stateInfoA.IsName("idle") || stateInfoA.IsName("walk") || stateInfoA.IsName("backwalk") || stateInfoA.IsName("block")) && stateInfoB.IsName("kick"))
                {
                    damageA.Kick();
                }

                if ((stateInfoA.IsName("idle") || stateInfoA.IsName("walk") || stateInfoA.IsName("backwalk") || stateInfoA.IsName("block")) && stateInfoB.IsName("combo"))
                {
                    damageA.Combo();
                }

                if ((stateInfoA.IsName("punch") || stateInfoA.IsName("kick") || stateInfoA.IsName("combo")) && (stateInfoB.IsName("punch") || stateInfoB.IsName("kick") || stateInfoB.IsName("combo")))
                {
                    int randomNumber = Random.Range(1, 3);
                    if (randomNumber == 1)
                    {
                        if (stateInfoB.IsName("punch"))
                        {
                            damageA.Punch();
                        }
                        if (stateInfoB.IsName("kick"))
                        {
                            damageA.Kick();
                        }
                        if (stateInfoB.IsName("combo"))
                        {
                            damageA.Combo();
                        }
                    }
                    else
                    {
                        if (stateInfoA.IsName("punch"))
                        {
                            damageB.Punch();
                        }
                        if (stateInfoA.IsName("kick"))
                        {
                            damageB.Kick();
                        }
                        if (stateInfoA.IsName("combo"))
                        {
                            damageB.Combo();
                        }
                    }
                }

            }

        }

        collisionCooldown = cooldownDuration;
    }
}
