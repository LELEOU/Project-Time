using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    public float jumpForce = 10f; // Força do pulo
    public Transform groundCheck; // Verificador de contato com o chão
    public LayerMask groundLayer; // Camada do chão
    private bool isGrounded;

    private Rigidbody2D rb;
    private Animator animator;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        // Checa se está no chão
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);

        // Pulo (somente se estiver no chão)
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            Jump();
        }

        // Animação de pulo
        animator.SetBool("IsJumping", !isGrounded);
    }

    private void Jump()
    {
        rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
    }
}
