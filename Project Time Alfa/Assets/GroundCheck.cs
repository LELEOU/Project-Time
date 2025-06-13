using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    public Transform groundCheck; // Objeto para verificar o chão
    public float checkRadius = 0.2f; // Raio para detecção
    public LayerMask groundLayer; // Camada do chão
    private bool isGrounded;

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Verifica se está no chão usando OverlapCircle
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, groundLayer);

        // Evita movimento no ar
        if (!isGrounded)
        {
            rb.linearVelocity = new Vector2(0, rb.linearVelocity.y);
        }
    }

    void OnDrawGizmosSelected()
    {
        // Visualiza o raio de verificação no editor
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(groundCheck.position, checkRadius);
    }
}
