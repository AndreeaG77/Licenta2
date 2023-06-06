using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player1Movement : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float jumpSize;
    [SerializeField] private float scale;

    public AudioSource source;
    public AudioClip clip;

    private Rigidbody body;
    private Animator animator;
    private GameObject player;
    public bool isGrounded { get; set; }
    public bool spell { get; set; }
    public bool isMoving {get; set; }

    private void Awake()
    {
        body = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        player = GameObject.FindWithTag("player2");
        isGrounded=true;
    }

    
    void Update()
    {
        float direction = 0f;

        if (Input.GetKey(KeyCode.LeftArrow))
            {
                if(isGrounded && isMoving){
                    animator.SetBool("isWalkingBackwards", false);
                    animator.SetBool("isWalking", true);
                    animator.SetBool("isJumping", false);
                }
                direction = -1f;
                body.velocity = new Vector2(direction * speed, body.velocity.y);
            }
        if (Input.GetKey(KeyCode.RightArrow))
            {   
                if(isGrounded && isMoving){
                    animator.SetBool("isWalking", false);
                    animator.SetBool("isWalkingBackwards", true);
                    animator.SetBool("isJumping", false);
                }
                direction = 1f;
                body.velocity = new Vector2(direction * speed, body.velocity.y);
            }
        if (Input.GetKey(KeyCode.UpArrow) && isGrounded)
            {
                Jump();
            }
        
        if (direction != 0)
        {
            isMoving = true;
        }
        else 
        {
            isMoving = false;
            animator.SetBool("isWalkingBackwards", false);
            animator.SetBool("isWalking", false);
        }
        if (isGrounded)
        {
            animator.SetBool("isJumping", false);
        }
        else 
        {
            animator.SetBool("isJumping", true);
        }

        if(Input.GetKeyDown(KeyCode.P)){
            animator.SetBool("punch1", true);
        }
        if(Input.GetKeyUp(KeyCode.P)){
            animator.SetBool("punch1", false);
        }

        if(Input.GetKeyDown(KeyCode.K)){
            animator.SetBool("kick1", true);
        }
        if(Input.GetKeyUp(KeyCode.K)){
            animator.SetBool("kick1", false);
        }

        if(Input.GetKeyDown(KeyCode.O) && Input.GetKeyDown(KeyCode.L)){
            player = GameObject.FindWithTag("player2");
            if (player.name == "Sorceron(Clone)")
            {
                source.clip = clip;
                source.PlayOneShot(source.clip);
            }           
            animator.SetBool("combo1", true);
        }
        else{
            animator.SetBool("combo1", false);
        }

        if(Input.GetKeyDown(KeyCode.I)){
            animator.SetBool("block1", true);
        }
        if(Input.GetKeyUp(KeyCode.I)){
            animator.SetBool("block1", false);
        }
        
    }
    private void Jump()
    {
        body.velocity = new Vector2(body.velocity.x, jumpSize);
        animator.SetBool("isJumping", true);
        animator.SetBool("isWalking", false);
        animator.SetBool("isWalkingBackwards", false);
        isGrounded = false;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("spell") || collision.gameObject.CompareTag("spell2"))
        {
            isGrounded = true;
        }
    }

    public float getSpeed()
    {
        return speed;
    }

    public float getJumpSize()
    {
        return jumpSize;
    }

    public void setSpeed(float newSpeed)
    {
        speed = newSpeed;
    }

    public void setJumpSize(float newJumpSize)
    {
        jumpSize = newJumpSize;
    }
}
