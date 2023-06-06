using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class CPUScript3 : MonoBehaviour
{
    private float speed = 2f;
    private float maxAttackTime = 8f;
    private float minAttackTime = 2f;
    private GameObject player;
    private GameObject enemy;
    private Transform playerT;
    private CPUShootRifle shoot;
    private bool nexus;
    private bool sorceron;
    private float timeBetweenAttacks;
    public bool isMoving = true;
    public bool isChasing;
    public bool shouldAttack;
    private float randomTime;
    public int randomAttack;
    private string[] attacks = new string[] { "punch1", "kick1", "combo1" };
    private float[] probabilities;
   // private Rigidbody body;
    private Animator animator;

    private void Start()
    {
        probabilities = new float[] { 0.25f, 0.35f, 0.40f };
        enemy = GameObject.FindWithTag("player2");
        if (enemy.name == "Nexus(Clone)")
        {
            nexus = true;
            shoot = enemy.GetComponent<CPUShootRifle>();
        }
        if (enemy.name == "Sorceron(Clone)")
        {
            sorceron = true;
        }
        player = GameObject.FindWithTag("player1");
        playerT = player.transform;
        timeBetweenAttacks = maxAttackTime;
        //body = GetComponent<Rigidbody>();
        animator = enemy.GetComponent<Animator>();
        randomTime = Random.Range(0f, 3f);
        StartCoroutine(MoveObject());
    }

    private IEnumerator MoveObject()
    {
        enemy = GameObject.FindWithTag("player2");
        animator = enemy.GetComponent<Animator>();

        while (isMoving)
        {
            if (speed > 0)
            {
                animator.SetBool("isWalkingBackwards", false);
                animator.SetBool("isWalking", true);
            }
            else
            {
                animator.SetBool("isWalkingBackwards", true);
                animator.SetBool("isWalking", false);
            }

            // Move the object on the x-axis
            transform.Translate(Vector3.forward * speed * Time.deltaTime);

            randomTime -= Time.deltaTime;

            if (randomTime < 0f)
            {
                speed *= -1f;
                randomTime = Random.Range(2f, 4f);
            }

            timeBetweenAttacks -= Time.deltaTime;

            if (timeBetweenAttacks <= 0f)
            {
                isMoving = false;

                // Stop moving
                StopCoroutine(MoveObject());

                randomAttack = GetRandomAction();
                if (nexus && randomAttack == 0)
                {
                    StartCoroutine(AttackCoroutine());
                }
                else if (sorceron && randomAttack == 2)
                {
                    StartCoroutine(AttackCoroutine());
                }
                else
                {
                    isChasing = true;
                    // Start the attack coroutine
                    StartCoroutine(ChaseCoroutine());
                }

            }

            yield return null;
        }
    }

    private int GetRandomAction()
    {
        float randomValue = Random.value;
        float cumulativeProbability = 0f;
        probabilities = new float[] { 0.25f, 0.35f, 0.40f };

        for (int i = 0; i < attacks.Length; i++)
        {
            cumulativeProbability += probabilities[i];
            if (randomValue <= cumulativeProbability)
            {
                return i;
            }
        }

        // Fallback to the last action if no match found (shouldn't happen if probabilities are correct)
        return attacks.Length - 1;
    }

    private IEnumerator AttackCoroutine()
    {
        //randomAttack = (int)Random.Range(0f, 3f);
        enemy = GameObject.FindWithTag("player2");
        animator = enemy.GetComponent<Animator>();

        animator.SetBool(attacks[randomAttack], true);
        if (nexus && randomAttack == 0)
        {
            shoot.Shoot();
        }
        yield return new WaitForSeconds(1.5f);
        animator.SetBool(attacks[randomAttack], false);

        randomAttack = 0;

        timeBetweenAttacks = Random.Range(minAttackTime, maxAttackTime);
        isMoving = true;

        speed *= -1f;
        StartCoroutine(MoveObject());
    }

    private IEnumerator ChaseCoroutine()
    {
        enemy = GameObject.FindWithTag("player2");
        animator = enemy.GetComponent<Animator>();

        if (speed < 0f)
        {
            speed *= -1f;
            animator.SetBool("isWalkingBackwards", false);
            animator.SetBool("isWalking", true);

        }

        while (isChasing)
        {
            transform.Translate(Vector3.forward * speed * Time.deltaTime);

            if (shouldAttack)
            {
                isChasing = false;

                StopCoroutine(ChaseCoroutine());

                animator.SetBool("isWalkingBackwards", false);
                animator.SetBool("isWalking", false);

                shouldAttack = false;
                StartCoroutine(AttackCoroutine());
            }

            yield return null;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if ((collision.gameObject.CompareTag("player1") || collision.gameObject.CompareTag("wall")) && isMoving)
        {
            speed *= -1;
        }

        if (collision.gameObject.CompareTag("player1") && isChasing)
        {
            shouldAttack = true;
        }
    }

    public void StartMyCoroutine()
    {
        StartCoroutine(MoveObject());
    }
}