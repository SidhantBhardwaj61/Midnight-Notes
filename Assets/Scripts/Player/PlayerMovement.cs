using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement Variables")]
    [SerializeField] float movementSpeed = 5f;
    [SerializeField] float runSpeed = 10f;

    [Header("Input")]
    public Vector2 movement;

    [Header("References")]
    Animator animator;
    Rigidbody2D rb;

    public static bool isPlayerWalkable = true;

    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    public void DisablePlayer()
    {
        isPlayerWalkable = false;
        animator.SetFloat("Speed" , 0);
    }

    public void EnablePlayer()
    {
        isPlayerWalkable = true;
    }

    void Update()
    {
        if (!isPlayerWalkable) return;
        MovementInput();
    }

    void FixedUpdate()
    {
        if (!isPlayerWalkable) return;
        Movement();
    }

    void MovementInput()
    {
        //Input
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        //Setting up animation
        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);
    }

    void Movement()
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
