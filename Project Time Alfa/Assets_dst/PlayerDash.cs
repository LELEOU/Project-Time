using UnityEngine;
using System.Collections;

public class PlayerDash : MonoBehaviour
{
    public float dashSpeed = 15f;
    public float dashDuration = 0.2f;
    public float dashCooldown = 1f;

    private Rigidbody2D rb;
    private Animator animator;
    private bool isDashing = false;
    private float dashCooldownTimer;

    private PlayerMovement movement; // Referência para controle do Flip

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        movement = GetComponent<PlayerMovement>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl) && dashCooldownTimer <= 0)
        {
            StartCoroutine(Dash());
        }

        // Reduzir o tempo de espera do dash
        if (dashCooldownTimer > 0)
            dashCooldownTimer -= Time.deltaTime;
    }

    IEnumerator Dash()
    {
        if (isDashing) yield break;

        isDashing = true;
        dashCooldownTimer = dashCooldown;

        animator.SetTrigger("Dash");

        // Define direção do Dash
        float dashDirection = movement.transform.localScale.x > 0 ? 1 : -1;
        rb.linearVelocity = new Vector2(dashDirection * dashSpeed, rb.linearVelocity.y);

        yield return new WaitForSeconds(dashDuration);

        rb.linearVelocity = Vector2.zero;
        isDashing = false;
        animator.ResetTrigger("Dash");
    }
}
