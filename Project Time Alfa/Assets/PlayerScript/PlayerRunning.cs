using UnityEngine;

public class PlayerRunning : MonoBehaviour
{
    public float walkSpeed = 4f;  // Velocidade de caminhada (pode ser ajustada)
    public float runSpeed = 8f;   // Velocidade de corrida
    private Rigidbody2D rb;
    private Animator animator;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        float moveInput = Input.GetAxisRaw("Horizontal");
        bool isRunning = Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.RightControl);

        if (moveInput != 0)
        {
            if (isRunning)
            {
                rb.linearVelocity = new Vector2(moveInput * runSpeed, rb.linearVelocity.y);
                animator.SetBool("IsRunning", true);
            }
            else
            {
                rb.linearVelocity = new Vector2(moveInput * walkSpeed, rb.linearVelocity.y);
                animator.SetBool("IsRunning", false);
            }
        }
        else
        {
            rb.linearVelocity = new Vector2(0, rb.linearVelocity.y);
            animator.SetBool("IsRunning", false);
        }
    }
}
