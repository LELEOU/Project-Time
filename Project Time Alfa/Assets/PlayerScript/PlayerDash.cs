using UnityEngine;

public class PlayerDash : MonoBehaviour
{
    public float dashSpeed = 10f; // Velocidade do Dash
    public float dashDuration = 0.2f; // Duração do Dash

    private Rigidbody2D rb;
    private Animator animator;
    private bool isDashing;
    private float dashTime;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>(); // Localiza automaticamente o componente Animator
    }

    void Update()
    {
        // Inicia o Dash ao pressionar "Shift" (se não estiver em Dash)
        if (Input.GetKeyDown(KeyCode.LeftShift) && !isDashing)
        {
            StartDash();
        }
    }

    void StartDash()
    {
        isDashing = true;
        dashTime = dashDuration;

        // Define o Trigger "IsDashing" para ativar a animação
        animator.SetTrigger("IsDashing");
    }

    void FixedUpdate()
    {
        if (isDashing)
        {
            if (dashTime > 0)
            {
                // Calcula a direção do Dash com base no movimento horizontal atual
                float dashDirection = transform.localScale.x > 0 ? 1 : -1; // Direção baseada no flip do player
                rb.linearVelocity = new Vector2(dashDirection * dashSpeed, rb.linearVelocity.y);

                dashTime -= Time.fixedDeltaTime;
            }
            else
            {
                // Finaliza o Dash
                EndDash();
            }
        }
    }

    void EndDash()
    {
        isDashing = false;
        rb.linearVelocity = new Vector2(0, rb.linearVelocity.y); // Para o movimento horizontal após o Dash
    }
}
