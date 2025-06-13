using UnityEngine;
using UnityEngine.UI;

public class InventorySlotUI : MonoBehaviour
{
    public Image icon;         // Componente de imagem que exibirá o ícone do item
    public Text quantityText;  // Componente de texto que exibirá a quantidade (se for maior que 1)

    // Atualiza o slot para exibir o item
    public void SetItem(InventoryItem item)
    {
        if (item != null)
        {
            icon.sprite = item.icon;
            icon.enabled = true;
            quantityText.text = item.quantity > 1 ? item.quantity.ToString() : "";
        }
    }

    // Limpa o slot, removendo qualquer item exibido
    public void ClearSlot()
    {
        icon.sprite = null;
        icon.enabled = false;
        quantityText.text = "";
    }
}
