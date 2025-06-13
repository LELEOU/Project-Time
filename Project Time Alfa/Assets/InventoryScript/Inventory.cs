using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public static Inventory Instance; // Singleton para acesso global

    public List<InventoryItem> items = new List<InventoryItem>();
    public int inventorySize = 20; // Número máximo de slots

    void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    // Adiciona um item ao inventário. Se o item já existir e for empilhável, incrementa a quantidade.
    public bool AddItem(InventoryItem newItem)
    {
        bool itemAdded = false;

        // Procura item existente (supondo que items com o mesmo id possam ser empilhados)
        foreach (var item in items)
        {
            if (item.id == newItem.id)
            {
                item.quantity += newItem.quantity;
                itemAdded = true;
                break;
            }
        }

        // Se não existir, adiciona o item se houver espaço
        if (!itemAdded)
        {
            if (items.Count < inventorySize)
            {
                items.Add(newItem);
                itemAdded = true;
            }
            else
            {
                Debug.Log("Inventário cheio!");
                return false;
            }
        }

        // Após adicionar o item, atualiza a UI do inventário, se houver
        InventoryUI ui = FindObjectOfType<InventoryUI>();
        if (ui != null)
        {
            ui.UpdateUI();
        }

        return true;
    }

    // Remove uma quantidade de um item do inventário
    public bool RemoveItem(int id, int quantity)
    {
        foreach (var item in items)
        {
            if (item.id == id)
            {
                if (item.quantity >= quantity)
                {
                    item.quantity -= quantity;
                    if (item.quantity <= 0)
                        items.Remove(item);
                    return true;
                }
            }
        }
        return false;
    }
}
