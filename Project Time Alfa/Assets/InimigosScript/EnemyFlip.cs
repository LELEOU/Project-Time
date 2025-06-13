using UnityEngine;

public class EnemyFlip : MonoBehaviour
{
    private Rigidbody2D rb;
    private float lastVelocityX;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        lastVelocityX = rb.linearVelocity.x;
    }

    void Update()
    {
        Flip();
    }

    void Flip()
    {
        // Verifica se houve mudança de direção no eixo X
        if ((rb.linearVelocity.x > 0 && lastVelocityX <= 0) || (rb.linearVelocity.x < 0 && lastVelocityX >= 0))
        {
            // Inverte o eixo X do objeto (Flip)
            Vector3 localScale = transform.localScale;
            localScale.x *= -1;
            transform.localScale = localScale;

            // Atualiza a última velocidade no eixo X
            lastVelocityX = rb.linearVelocity.x;
        }
    }
}
