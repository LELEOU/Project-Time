using UnityEngine;

[System.Serializable]
public class InventoryItem
{
    public int id;               // Identificador único do item
    public string itemName;      // Nome do item
    public Sprite icon;          // Ícone para exibir na UI
    public int quantity;         // Quantidade do item
    public string description;   // Descrição do item (opcional)
}
