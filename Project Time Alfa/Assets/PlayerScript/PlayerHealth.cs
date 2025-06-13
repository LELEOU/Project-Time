using UnityEngine;
using UnityEngine.SceneManagement; // Para reiniciar ou carregar o Game Over

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 15; // Vida máxima do jogador
    private int currentHealth;

    private Animator animator; // Referência ao Animator
    public GameObject gameOverUI; // UI de Game Over

    private bool isDead = false;

    void Start()
    {
        animator = GetComponent<Animator>(); // Atribui automaticamente o Animator
        currentHealth = maxHealth; // Define a vida inicial
        gameOverUI.SetActive(false); // Garante que o Game Over está desativado no início
    }

    public void TakeDamage(int damage)
    {
        if (isDead) return; // Evita que tome dano após morrer

        currentHealth -= damage;

        // Executa a animação de dano
        animator.SetTrigger("TakeDamage");

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        isDead = true;

        // Executa a animação de morte
        animator.SetTrigger("Die");

        // Mostra a tela de Game Over após um curto atraso
        Invoke("ShowGameOver", 1.5f); // Tempo para finalizar a animação
    }

    void ShowGameOver()
    {
        gameOverUI.SetActive(true); // Ativa a tela de Game Over
        Time.timeScale = 0f; // Pausa o jogo
    }

    // Método para reiniciar o jogo ou cena
    public void RestartGame()
    {
        Time.timeScale = 1f; // Reseta o tempo
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); // Recarrega a cena atual
    }
}
