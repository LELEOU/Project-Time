using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 3;
    private int currentHealth;

    void Start()
    {
        currentHealth = maxHealth;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            currentHealth--;
            Debug.Log("Vida restante: " + currentHealth);

            if (currentHealth <= 0)
            {
                Debug.Log("Game Over!");
                Destroy(gameObject); // Destroi o jogador
            }
        }
    }
}
