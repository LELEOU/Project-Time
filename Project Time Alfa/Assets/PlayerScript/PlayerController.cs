using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 6f; // Velocidade de movimento
    public float groundCheckDistance = 0.2f; // Distância para checar se está no chão
    public Transform groundCheck; // Referência para o objeto que verifica o chão
    public LayerMask groundLayer; // Camada do chão

    private Rigidbody2D rb;
    private Animator animator;
    private float moveInput;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        // Detecta movimento horizontal
        moveInput = Input.GetAxisRaw("Horizontal");
        animator.SetFloat("Speed", Mathf.Abs(moveInput));

        // Checa o movimento e realiza o flip
        if (moveInput > 0 && transform.localScale.x < 0)
        {
            Flip();
        }
        else if (moveInput < 0 && transform.localScale.x > 0)
        {
            Flip();
        }
    }

    void FixedUpdate()
    {
        // Move o personagem horizontalmente
        rb.linearVelocity = new Vector2(moveInput * moveSpeed, rb.linearVelocity.y);
    }

    private void Flip()
    {
        Vector3 localScale = transform.localScale;
        localScale.x *= -1; // Inverte o eixo X
        transform.localScale = localScale;
    }

    // Visualiza a checagem do chão (para debug)
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(groundCheck.position, Vector3.down * groundCheckDistance);
    }
}
