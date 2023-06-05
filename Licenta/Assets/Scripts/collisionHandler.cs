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

    private void Start()
    {
        characterA = GameObject.FindWithTag("player2");
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
            if (characterA.name == "Sorceron(Clone)")
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
            if (damageA != null)
            {
                damageA.Punch();
            }

        }

        if (collision.gameObject.CompareTag("player2")){

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

        if (collision.gameObject.CompareTag("player2")){
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
}
