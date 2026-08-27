using UnityEngine;

public class PlayerMovement : MonoBehaviour
{   
    private Rigidbody2D rb;
    private bool isGrounded;
    private bool jumpRequested;

    // permet de mettre la variable en privee mais elle reste accessible dans l'inspecteur
    [SerializeField] private Transform groundCheck;
    [SerializeField] private float groundCheckRadius;
    [SerializeField] private LayerMask layerMask;

    [SerializeField] private float jumpForce;
    [SerializeField] private float playerSpeed;

    [SerializeField] private float fallGravity = 2.5f;
    [SerializeField] private float lowJumpGravity = 2f;

    void Awake()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Space) && isGrounded)
        {
            jumpRequested = true;
        }

        isGrounded = Physics2D.OverlapCircle(groundCheck.transform.position,groundCheckRadius,layerMask);
    }

    void FixedUpdate()
    {   
        rb.linearVelocity = new Vector2(playerSpeed, rb.linearVelocity.y);

        if (jumpRequested)
        {   
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, 0f);
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            jumpRequested = false;
        }

        // double gravite pour ameliore le game feel
        if (rb.linearVelocity.y < 0)
        {
            rb.linearVelocity += Vector2.up * Physics2D.gravity.y * (fallGravity - 1) * Time.fixedDeltaTime;
        }
        else if (rb.linearVelocity.y > 0 && !Input.GetKey(KeyCode.Space))
        {
            rb.linearVelocity += Vector2.up * Physics2D.gravity.y * (lowJumpGravity - 1) * Time.fixedDeltaTime;
        }

    }

    private void OnDrawGizmos()
    {   
        if (groundCheck != null)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(groundCheck.position,groundCheckRadius);
        }
    }

}
