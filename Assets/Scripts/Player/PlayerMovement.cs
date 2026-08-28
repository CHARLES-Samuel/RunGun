using UnityEngine;

/**
    Gere les mouvements du personnage
*/
public class PlayerMovement : MonoBehaviour
{   
    private Rigidbody2D rb;
    public bool isGrounded;
    private bool jumpRequested;
    private PlayerHealth playerHealth;

    // permet de mettre la variable en privee mais elle reste accessible dans l'inspecteur
    [SerializeField] private Transform groundCheckLeft;
    [SerializeField] private Transform groundCheckRight;
    [SerializeField] private float groundCheckRadius;
    [SerializeField] private LayerMask layerMask;

    [SerializeField] private float jumpForce;
    [SerializeField] private float playerSpeed;

    [SerializeField] private float fallGravity = 2.5f;
    [SerializeField] private float lowJumpGravity = 2f;

    [SerializeField] private int blockDamage = 1;
    [SerializeField] private float damageInterval = 0.2f; // Tous les combien de temps (ex: 0.2 sec = 5 fois par seconde)
    private float damageTimer = 0f;

    void Awake()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        playerHealth = gameObject.GetComponent<PlayerHealth>();
    }

    void Update()
    {
        bool leftFoot = Physics2D.OverlapCircle(groundCheckLeft.position, groundCheckRadius, layerMask);
        bool rightFoot = Physics2D.OverlapCircle(groundCheckRight.position, groundCheckRadius, layerMask);

        isGrounded = leftFoot || rightFoot;

        if (Input.GetKey(KeyCode.Space) && isGrounded)
        {
            jumpRequested = true;
        }

        if (Mathf.Abs(rb.linearVelocity.x) < 0.1f) 
        {
            damageTimer += Time.deltaTime;

            if (damageTimer >= damageInterval)
            {
                playerHealth.TakeDamage(blockDamage);
                damageTimer = 0f;
            }
        }
        else
        {
            damageTimer = 0f; 
        }
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
        if (groundCheckLeft != null && groundCheckRight != null)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(groundCheckLeft.position, groundCheckRadius);
            Gizmos.DrawWireSphere(groundCheckRight.position, groundCheckRadius);
        }
    }

}
