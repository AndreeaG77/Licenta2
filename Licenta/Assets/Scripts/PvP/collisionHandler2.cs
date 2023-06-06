using System.Collections;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class collisionHandler2 : MonoBehaviour
{

    private float collisionCooldown = 0f;
    private float cooldownDuration = 0.5f;
    private GameObject characterA;
    private damage2 damageA;
    private Animator animatorA;

    private void Start()
    {
        characterA = GameObject.FindWithTag("player2");
        damageA = characterA.GetComponent<damage2>();
        animatorA = characterA.GetComponent<Animator>();
    }
    private void Update()
    {
        if (collisionCooldown > 0f)
        {
            collisionCooldown -= Time.deltaTime;
        }

        if (Input.GetKeyDown(KeyCode.F) && Input.GetKeyDown(KeyCode.G))
        {
            GameObject characterB = GameObject.FindWithTag("player1");
            if (characterB.name == "Sorceron(Clone)")
            {
                characterA = GameObject.FindWithTag("player2");
                damageA = characterA.GetComponent<damage2>();
                animatorA = characterA.GetComponent<Animator>();
                StartCoroutine(spellDamage(damageA));

            }
        }
    }

    IEnumerator spellDamage(damage2 damageA)
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
            characterA = GameObject.FindWithTag("player2");
            damageA = characterA.GetComponent<damage2>();
            animatorA = characterA.GetComponent<Animator>();
            damageA.Punch();

        }

        if (collision.gameObject.CompareTag("player1"))
        {
            GameObject characterB = collision.gameObject;
            Animator animatorB = characterB.GetComponent<Animator>();
            characterA = GameObject.FindWithTag("player2");
            damageA = characterA.GetComponent<damage2>();
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

        if (collision.gameObject.CompareTag("player1"))
        {
            GameObject characterB = collision.gameObject;
            Animator animatorB = characterB.GetComponent<Animator>();
            characterA = GameObject.FindWithTag("player2");
            damageA = characterA.GetComponent<damage2>();
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

            }

        }

        collisionCooldown = cooldownDuration;
    }
}
