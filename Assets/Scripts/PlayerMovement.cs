using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement Variables")]
    [SerializeField] float movementSpeed = 5f;
    [SerializeField] float runSpeed = 10f;

    [Header("Input")]
    Vector2 movement;

    [Header("References")]
    Animator animator;
    Rigidbody2D rb;

    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        //Input
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        //Setting up animation
        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);
    }

    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
        {
            animator.speed = 1.5f;
            rb.MovePosition(rb.position + movement * runSpeed * Time.fixedDeltaTime);
        }
        else
        {
            animator.speed = 1f;
            rb.MovePosition(rb.position + movement * movementSpeed * Time.fixedDeltaTime);
        }
    }
}
