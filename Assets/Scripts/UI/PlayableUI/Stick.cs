using UnityEngine;

public class Stick : MonoBehaviour
{
    [Header("StickVariables")]
    [SerializeField] float stickSpeed = 5f;
    int stickDirection = 1;
    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("Hit : " + other.gameObject.name);
        //change direction if at the end of the moving area
        if (other.gameObject.tag == "ScoreWall")
        {
            stickDirection = stickDirection * -1;
        }
    }

    void FixedUpdate()
    {
        if (MovingStick.isStickActive && MovingStick.isMoving)
        {
            rb.linearVelocity = new Vector2(stickDirection * stickSpeed, 0f);

            if (Input.GetKeyDown(KeyCode.Return))
            {
                rb.linearVelocity = Vector2.zero;
                MovingStick.isMoving = false;
            }
        }
    }
}
