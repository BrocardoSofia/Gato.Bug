using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private BoxCollider2D coll;
    private int jumpCount;

    private float dirX;
    [SerializeField] private float moveSpeed = 7f;
    [SerializeField] private float jumpForce = 14f;

    [SerializeField] private LayerMask jumpableGround;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();
        dirX = 0f;
        jumpCount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (rb.bodyType == RigidbodyType2D.Dynamic)
        {
            dirX = Input.GetAxisRaw("Horizontal");
            rb.linearVelocity = new Vector2(dirX * moveSpeed, rb.linearVelocity.y);

            if (Input.GetButtonDown("Jump") && (IsGrounded() || jumpCount == 0))
            {
                rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
                jumpCount++;
            }
        }
    }

    private bool IsGrounded()
    {
        //creo una nueva caja que esta un poquito mas abajo que la caja del personaje
        //para ver si se superpone con otra caja
        bool grounded = Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, 
            Vector2.down, .1f, jumpableGround);

        if (grounded)
        {
            jumpCount = 0;
        }

        return grounded;
    }
}
