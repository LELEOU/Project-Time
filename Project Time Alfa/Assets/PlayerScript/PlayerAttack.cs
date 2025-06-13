using UnityEngine;
using System.Collections;

public class PlayerAttack : MonoBehaviour
{
    public Collider2D attackCollider; // Hitbox do ataque
    public float attackDuration = 0.8f; // Tempo que o ataque dura
    public int attackDamage = 10; // Dano causado pelo ataque

    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
        attackCollider.enabled = false; // Hitbox começa desativada
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // Botão esquerdo do mouse
        {
            Attack();
        }
    }

    void Attack()
    {
        animator.SetTrigger("Attack"); // Inicia a animação de ataque
        StartCoroutine(ActivateAttackCollider()); // Ativa o collider durante o ataque
    }

    IEnumerator ActivateAttackCollider()
    {
        attackCollider.enabled = true; // Ativa o hitbox
        yield return new WaitForSeconds(attackDuration); // Espera a duração do ataque
        attackCollider.enabled = false; // Desativa o hitbox
    }

    // Detecta inimigos na hitbox do ataque
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Verifica se o inimigo entrou na hitbox
        if (collision.CompareTag("Enemy"))
        {
            // Tenta encontrar o script de vida do inimigo
            EnemyHealth enemyHealth = collision.GetComponent<EnemyHealth>();

            if (enemyHealth != null)
            {
                enemyHealth.TakeDamage(attackDamage); // Causa dano ao inimigo
            }
        }
    }
}
