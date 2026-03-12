using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement Settings")]
    public float walkSpeed = 5f;
    public float runSpeed = 10f;
    public float jumpForce = 7f;

    [Header("Detection Settings")]
    public float rayDistance = 1.5f;
    public LayerMask collectableLayer;

    #region Variables
    private Rigidbody2D rb;
    private bool isGrounded;
    private int jumpCount; // Contador para el doble salto
    private int maxJumps = 2;
    #endregion

    #region Methods
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Move();
        Jump();
        CheckForCollectables();
    }

    void Move()
    {
        float move = Input.GetAxis("Horizontal");
        bool isRunning = Input.GetKey(KeyCode.LeftShift);

        float currentSpeed = isRunning ? runSpeed : walkSpeed;

        rb.linearVelocity = new Vector2(move * currentSpeed, rb.linearVelocity.y);

        //Voltear el personaje segun la direccion
        if (move > 0) transform.localScale = new Vector3(1, 1, 1);
        else if (move < 0) transform.localScale = new Vector3(-1, 1, 1);
    }

    void Jump()
    {
        //Permitir saltar si esta en el suelo o si le queda un salto extra
        if (Input.GetKeyDown(KeyCode.Space) && (isGrounded || jumpCount < maxJumps))
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
            jumpCount++;
            isGrounded = false;
        }
    }

    void CheckForCollectables()
    {
        // Disparamos el rayo hacia donde mira el personaje
        Vector2 direction = transform.localScale.x > 0 ? Vector2.right : Vector2.left;
        RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, rayDistance, collectableLayer);

        // Dibujar el rayo en el editor (solo visible en escena)
        Debug.DrawRay(transform.position, direction * rayDistance, Color.red);

        if (hit.collider != null)
        {
            // Si presionas la tecla E recolectas el objeto
            if (Input.GetKeyDown(KeyCode.E))
            {
                Destroy(hit.collider.gameObject);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
            jumpCount = 0; // Reiniciamos el contador al tocar suelo
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }
    #endregion
}
