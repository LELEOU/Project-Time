using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public float moveSpeed = 3f;               // Velocidade do inimigo
    public Transform target;                   // Referência ao jogador
    public Transform groundCheck;              // Objeto para verificar o chão
    public float checkRadius = 0.2f;           // Raio para detecção do chão
    public LayerMask groundLayer;              // Camada do chão
    public LayerMask obstacleMask;             // Camada dos obstáculos (paredes)
    public float viewDistance = 10f;           // Distância máxima de visão

    private Rigidbody2D rb;
    private Vector2 movement;
    private bool isGrounded;
    private bool isChasing = false;
    private int patrolDirection = 1;           // 1 = direita, -1 = esquerda

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Verifica se o inimigo está no chão
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, groundLayer);

        // Se o target (player) existir, tenta detectar se ele está visível
        if (target != null)
        {
            Vector2 directionToPlayer = target.position - transform.position;
            float distanceToPlayer = directionToPlayer.magnitude;
            bool playerVisible = false;

            // Verifica se o player está dentro da distância de visão
            if (distanceToPlayer <= viewDistance)
            {
                // Raycast para verificar se há algum obstáculo entre o inimigo e o player
                RaycastHit2D hit = Physics2D.Raycast(transform.position, directionToPlayer.normalized, distanceToPlayer, obstacleMask);
                // Se nada obstruiu a linha de visão, o player está visível
                if (hit.collider == null)
                {
                    playerVisible = true;
                }
            }

            if (playerVisible)
            {
                isChasing = true;
                movement = directionToPlayer.normalized;
            }
            else
            {
                isChasing = false;
            }
        }
        else
        {
            isChasing = false;
        }

        // Se não estiver perseguindo o player, realiza patrulha (anda de um lado pro outro)
        if (!isChasing)
        {
            movement = new Vector2(patrolDirection, 0);
        }
    }

    void FixedUpdate()
    {
        if (isGrounded)
        {
            rb.linearVelocity = new Vector2(movement.x * moveSpeed, rb.linearVelocity.y);
        }
    }

    // Ao colidir com um obstáculo durante a patrulha, inverte a direção
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Verifica se o objeto colidido está na camada de obstáculos
        if (!isChasing && ((obstacleMask.value & (1 << collision.gameObject.layer)) > 0))
        {
            patrolDirection *= -1;
        }
    }

    void OnDrawGizmosSelected()
    {
        // Visualiza o raio de verificação do chão no editor
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(groundCheck.position, checkRadius);

        // Visualiza a distância de visão (linha azul)
        Gizmos.color = Color.blue;
        Gizmos.DrawLine(transform.position, transform.position + (Vector3)(Vector2.right * viewDistance));
    }
}
