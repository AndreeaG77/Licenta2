using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class CPUScript : MonoBehaviour
{
    private float speed = 3f;
    private float maxAttackTime = 10f;
    private GameObject player;
    private Transform playerT;
    private float timeBetweenAttacks;
    private bool isMoving = true;
    private bool isChasing;
    private bool shouldAttack;
    private float randomTime;
    public int randomAttack;
    private string[] attacks = new string[] { "punch1", "kick1", "combo1" };

    private Rigidbody body;
    private Animator animator;

    private void Start()
    {
        player = GameObject.FindWithTag("player1");
        playerT = player.transform;
        timeBetweenAttacks = maxAttackTime;
        body = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        randomTime = Random.Range(0f, 3f);
        StartCoroutine(MoveObject());
    }

    private IEnumerator MoveObject()
    {
        while (isMoving)
        {
            if(speed > 0)
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

                isChasing = true;
                // Start the attack coroutine
                StartCoroutine(ChaseCoroutine());
            }

            yield return null;
        }
    }

    private IEnumerator AttackCoroutine()
    {
        randomAttack = (int)Random.Range(0f, 3f);

        animator.SetBool(attacks[randomAttack], true);
        yield return new WaitForSeconds(1.5f);
        animator.SetBool(attacks[randomAttack], false);

        randomAttack = 0;

        timeBetweenAttacks = Random.Range(0f, maxAttackTime);
        isMoving = true;

        speed *= -1f;
        StartCoroutine(MoveObject());
    }

    private IEnumerator ChaseCoroutine()
    {
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
}