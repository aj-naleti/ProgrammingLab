using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    [SerializeField] private float movementSpeed;
    [SerializeField] private float jumpVelocity;
    [SerializeField] private float groundCheckDistance;
    [SerializeField] private float stoppingDistance;

    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private LayerMask wallLayer;

    private Rigidbody2D rb;
    private float gravityScale;
    private int playerDirection;
    private Animator animator;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        gravityScale = rb.gravityScale;
        //animator = GetComponent<Animator>();
    }

    private void Update()
    {
        Walking();
        Jumping();
    }

    private void Walking()
    {
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.A))
        {
            //animator.SetBool("isRunning", true);
        }
        else
        {
            //animator.SetBool("isRunning", false);
        }

        if (Input.GetKey(KeyCode.D) && !CheckIfPlayerShouldStop(Vector2.right))
        {
            transform.position += transform.right * movementSpeed * Time.deltaTime;
            transform.rotation = Quaternion.Euler(0, 0, 0);
            playerDirection = 1;
        }
        if (Input.GetKey(KeyCode.A) && !CheckIfPlayerShouldStop(Vector2.left))
        {
            transform.position += transform.right * movementSpeed * Time.deltaTime;
            transform.rotation = Quaternion.Euler(0, 180, 0);
            playerDirection = -1;
        }
    }

    private void Jumping()
    {
        var isGrounded = CheckIfGrounded();

        if(isGrounded)
        {
            //animator.SetBool("isInAir", false);
            if (Input.GetKeyDown(KeyCode.Space))
            {
                rb.AddForce(transform.up * jumpVelocity, ForceMode2D.Impulse);
            }
        }
        else
        {
            //animator.SetBool("isInAir", true);
        }
    }

    private bool CheckIfGrounded()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, groundCheckDistance, groundLayer);

        if (hit.collider) return true;
        else return false;
    }

    private bool CheckIfPlayerShouldStop(Vector2 direction)
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, stoppingDistance, wallLayer);

        if (hit.collider) return true;
        else return false;
    }

    public int ReturnPlayerDirection()
    {
        return playerDirection;
    }
}
