using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private BoxCollider2D coll;

    private float dirX;
    [SerializeField] private float moveSpeed = 7f;
    [SerializeField] private float jumpForce = 14f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();
        dirX = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (rb.bodyType == RigidbodyType2D.Dynamic)
        {
            dirX = Input.GetAxisRaw("Horizontal");
            rb.linearVelocity = new Vector2(dirX * moveSpeed, rb.linearVelocity.y); //se mueve horizontalmente

            if (Input.GetButtonDown("Jump"))
            {
                rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce); //cuando salta
            }
        }
    }
}
