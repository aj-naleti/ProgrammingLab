using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 6f;
    private Rigidbody2D rigidBody;
    private Vector2 movement;

    private void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        movement = new Vector2(horizontal, vertical);
    }

    private void FixedUpdate()
    {
        rigidBody.MovePosition(rigidBody.position + movement * speed * Time.fixedDeltaTime);
    }