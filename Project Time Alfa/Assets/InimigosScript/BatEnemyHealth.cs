using UnityEngine;

public class BatEnemyHealth : MonoBehaviour
{
    public int health = 20;
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Método chamado para aplicar dano no morcego
    public void TakeDamage(int amount)
    {
        health -= amount;
        Debug.Log("BatEnemy tomou " + amount + " de dano. Vida restante: " + health);
        
        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        animator.SetTrigger("Die");
        Debug.Log("BatEnemy morreu.");
        Destroy(gameObject, 1f);
    }
}
