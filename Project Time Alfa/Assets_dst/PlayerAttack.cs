using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [Header("Configurações de Ataque")]
    public float attackRange = 0.5f; // Alcance do ataque
    public LayerMask enemyLayer; // Layer dos inimigos
    public int attackDamage = 10; // Dano do ataque
    public Transform attackPoint; // Ponto de ataque

    private Animator animator;
    private bool isAttacking = false; // Flag para evitar ataques repetidos

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        // Se a tecla E for pressionada e não estiver atacando
        if (Input.GetKeyDown(KeyCode.E) && !isAttacking)
        {
            Attack();
        }
    }

    void Attack()
    {
        // Ativar a flag de ataque
        isAttacking = true;

        // Ativar animação de ataque
        animator.SetTrigger("Attack");

        // Iniciar o ataque com um tempo equivalente ao tempo da animação
        Invoke(nameof(ResetAttack), 0.5f); // Ajuste 0.5f para o tempo da sua animação de ataque

        // Detectar inimigos no alcance do ataque
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayer);

        foreach (Collider2D enemy in hitEnemies)
        {
            Debug.Log("Acertou " + enemy.name);
            if (enemy.GetComponent<Enemy>() != null)
            {
                enemy.GetComponent<Enemy>().TakeDamage(attackDamage);
            }
        }
    }

    void ResetAttack()
    {
        // Resetar a flag de ataque após a animação terminar
        isAttacking = false;
    }

    void OnDrawGizmosSelected()
    {
        if (attackPoint == null) return;

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
