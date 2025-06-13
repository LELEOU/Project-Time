using UnityEngine;
using UnityEngine.UI;

public class PlayerHUD : MonoBehaviour
{
    public Image healthBar;
    public Image staminaBar;
    public Image manaBar;

    private PlayerStats playerStats;

    void Start()
    {
        playerStats = FindFirstObjectByType<PlayerStats>();
        UpdateHUD();
    }

    void Update()
    {
        UpdateHUD();
    }

    void UpdateHUD()
    {
        if (playerStats == null || healthBar == null || staminaBar == null || manaBar == null) return;

        healthBar.fillAmount = playerStats.health / playerStats.maxHealth;
        staminaBar.fillAmount = playerStats.stamina / playerStats.maxStamina;
        manaBar.fillAmount = playerStats.mana / playerStats.maxMana;
    }
}
