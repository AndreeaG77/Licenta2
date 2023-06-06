using System.Collections;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class collisionHandler : MonoBehaviour
{

    private float collisionCooldown = 0f;
    private float cooldownDuration = 0.5f;
    private GameObject characterA;
    private damage damageA;
    private Animator animatorA;
    private damage2 damageB;

    private void Start()
    {
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

        if (Input.GetKeyDown(KeyCode.O) && Input.GetKeyDown(KeyCode.L))
        {
            GameObject characterB = GameObject.FindWithTag("player2");
            if (characterB.name == "Sorceron(Clone)")
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
        yield return new WaitForSeconds(1.5f);
        damageA.Combo();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collisionCooldown > 0f)
        {
            return;
        }

        if (collision.gameObject.CompareTag("bullet"))
        {
            characterA = GameObject.FindWithTag("player1");
            damageA = characterA.GetComponent<damage>();
            animatorA = characterA.GetComponent<Animator>();
            damageA.Punch();

        }

        if (collision.gameObject.CompareTag("player2")){

            GameObject characterB = collision.gameObject;
            Animator animatorB = characterB.GetComponent<Animator>();
            damageB = characterB.GetComponent<damage2>();
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

        if (collision.gameObject.CompareTag("player2")){
            GameObject characterB = collision.gameObject;
            Animator animatorB = characterB.GetComponent<Animator>();
            damageB = characterB.GetComponent<damage2>();
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
