using UnityEngine;

public class Coin : MonoBehaviour
{
    [Header("Movement Variables")]
    [SerializeField] float movementSpeed = 5f;

    [Header("Input")]
    Vector2 movement;
    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        //move the crosshair around
        //Input
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * movementSpeed * Time.fixedDeltaTime);
    }
}
