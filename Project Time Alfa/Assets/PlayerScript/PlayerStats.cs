using UnityEngine;
using UnityEngine.SceneManagement; // Para reiniciar ou carregar o Game Over

public class PlayerStats : MonoBehaviour
{
    public float health = 100;
    public float maxHealth = 100;
    public float stamina = 100;
    public float maxStamina = 100;
    public float mana = 100;
    public float maxMana = 100;

    [HideInInspector]
    public float lastDamageTaken = 0; // Último dano sofrido
    [HideInInspector]
    public float lastStaminaUsed = 0; // Última quantidade de stamina usada
    [HideInInspector]
    public float lastManaUsed = 0;    // Última quantidade de mana usada

    private Animator animator;
    public GameObject gameOverUI;
    private bool isDead = false;

    void Start()
    {
        animator = GetComponent<Animator>();
        gameOverUI.SetActive(false);
        health = maxHealth; // Define a vida inicial corretamente
        mana = maxMana;     // Define a mana inicial corretamente
    }

    // Método chamado quando o player toma dano
    public void TakeDamage(float amount)
    {
        if (isDead) return;

        lastDamageTaken = amount; // Registra o dano recebido
        health -= amount;
        health = Mathf.Clamp(health, 0, maxHealth); // Garante que a vida não fique abaixo de 0

        animator.SetTrigger("TakeDamage");
        Debug.Log("Player took " + amount + " damage. Health: " + health);

        if (health <= 0)
        {
            Die();
        }
    }

    // Método para usar stamina
    public void UseStamina(float amount)
    {
        lastStaminaUsed = amount; // Registra o gasto de stamina
        stamina -= amount;
        stamina = Mathf.Clamp(stamina, 0, maxStamina);
        Debug.Log("Player used " + amount + " stamina. Stamina: " + stamina);
    }

    // Método para usar mana
    public void UseMana(float amount)
    {
        lastManaUsed = amount; // Registra o gasto de mana
        mana -= amount;
        mana = Mathf.Clamp(mana, 0, maxMana);
        Debug.Log("Player used " + amount + " mana. Mana: " + mana);
    }

    void Die()
    {
        isDead = true;
        animator.SetTrigger("Die");
        Invoke("ShowGameOver", 1.5f);
    }

    void ShowGameOver()
    {
        gameOverUI.SetActive(true);
        Time.timeScale = 0f;
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
