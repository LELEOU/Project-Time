using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int maxHealth = 50; // Vida máxima do inimigo
    private int currentHealth;

    public int enemyDamage = 5; // Dano que o inimigo causa ao jogador

    void Start()
    {
        currentHealth = maxHealth; // Inicializa a vida com o valor máximo
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage; // Reduz a vida do inimigo
        Debug.Log($"Inimigo tomou {damage} de dano. Vida restante: {currentHealth}");

        if (currentHealth <= 0)
        {
            Die(); // Chama a função de morte quando a vida chega a zero
        }
    }

    void Die()
    {
        // Adicione aqui os efeitos de morte (animação, destruição, etc.)
        Debug.Log("Inimigo morreu!");
        Destroy(gameObject); // Destroi o inimigo
    }

    // Detecta a colisão do inimigo com o jogador
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // Chama a função de dano no jogador
            PlayerHealth playerHealth = collision.gameObject.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(enemyDamage); // Causa dano ao jogador
            }
        }
    }
}
