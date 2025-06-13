using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public float moveSpeed = 3f; // Velocidade do inimigo
    public Transform target; // Referência ao jogador

    private Rigidbody2D rb;
    private Vector2 movement;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Calcula a direção do jogador
        if (target != null)
        {
            Vector2 direction = (Vector2)target.position - rb.position;
            direction.Normalize();
            movement = direction;
        }
    }

    void FixedUpdate()
    {
        // Movimenta o inimigo em direção ao jogador
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
}
