using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [SerializeField] float runSpeed = 5f;
    [SerializeField] float jumpSpeed = 3f;
    [SerializeField] float climbSpeed = 5f;
    [SerializeField] Vector2 deathKick = new Vector2(25f, 25f);

    bool isAlive = true;

    Rigidbody2D rigidBody;
    Animator animator;
    CapsuleCollider2D bodyCollider;
    BoxCollider2D feet;
    float gravityScaleAtStart;

    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        bodyCollider = GetComponent<CapsuleCollider2D>();
        feet = GetComponent<BoxCollider2D>();
        gravityScaleAtStart = rigidBody.gravityScale;
    }

    void Update()
    {
        if (!isAlive)
        {
            return;
        }
        Run();
        Climb();
        Jump();
        Flip();
        Die();
    }

    private void Run()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        Vector2 playerVelocity = new Vector2(moveHorizontal * runSpeed,rigidBody.velocity.y);
        rigidBody.velocity = playerVelocity;

        bool playerHasHorizontalSpeed = Mathf.Abs(rigidBody.velocity.x) > Mathf.Epsilon;
        animator.SetBool("Running", playerHasHorizontalSpeed);
    }

    private void Flip()
    {
        bool playerHasHorizontalSpeed = Mathf.Abs(rigidBody.velocity.x) > Mathf.Epsilon;
        if (playerHasHorizontalSpeed)
        {
            transform.localScale = new Vector2(Mathf.Sign(rigidBody.velocity.x), 1f);
        }
    }

    private void Jump()
    {
        if (!feet.IsTouchingLayers(LayerMask.GetMask("Ground")))
        {
            return;
        }


        if (Input.GetButtonDown("Jump"))
        {
            Vector2 dodajBrzinuSkoka = new Vector2(0f, jumpSpeed);
            rigidBody.velocity += dodajBrzinuSkoka;
        }
    }

    private void Climb()
    {
        if (!feet.IsTouchingLayers(LayerMask.GetMask("Climbing")))
        {
            animator.SetBool("Climbing", false);
            rigidBody.gravityScale = gravityScaleAtStart;
            return;
        }

        float moveVertical = Input.GetAxis("Vertical");
        Vector2 climbVelocity = new Vector2(rigidBody.velocity.x, moveVertical * climbSpeed);
        rigidBody.velocity = climbVelocity;
        rigidBody.gravityScale = 0f;

        bool playerHasVerticalSpeed = Mathf.Abs(rigidBody.velocity.y) > Mathf.Epsilon;
        animator.SetBool("Climbing", playerHasVerticalSpeed);
    }

    private void Die()
    {
        if (bodyCollider.IsTouchingLayers(LayerMask.GetMask("Enemy", "Hazards")))
        {
            animator.SetTrigger("Dying");
            GetComponent<Rigidbody2D>().velocity = deathKick;
            if(isAlive)
            {
                FindObjectOfType<GameController>().Smrt();
            }
            isAlive = false; 
        }
    }  
}
