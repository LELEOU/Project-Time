using UnityEngine;

public class InventoryToggle : MonoBehaviour
{
    public GameObject inventoryUI; // Referência ao painel do inventário

    private bool isInventoryOpen = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            isInventoryOpen = !isInventoryOpen;
            inventoryUI.SetActive(isInventoryOpen);
            
            // Opcional: pausar o jogo enquanto o inventário estiver aberto
            Time.timeScale = isInventoryOpen ? 0f : 1f;
        }
    }
}
