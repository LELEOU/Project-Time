using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class InventoryUI : MonoBehaviour
{
    public GameObject inventoryPanel; // Container (por exemplo, um painel com Grid Layout) onde os slots serão instanciados
    public GameObject slotPrefab;     // Prefab do slot do inventário
    public int numberOfSlots = 20;    // Número total de slots disponíveis

    private List<GameObject> slots = new List<GameObject>();

    void Start()
    {
        // Cria os slots na interface
        for (int i = 0; i < numberOfSlots; i++)
        {
            GameObject slot = Instantiate(slotPrefab, inventoryPanel.transform);
            slots.Add(slot);
        }
        
        UpdateUI();
    }

    // Atualiza os slots da UI conforme os itens do inventário
    public void UpdateUI()
    {
        for (int i = 0; i < slots.Count; i++)
        {
            InventorySlotUI slotUI = slots[i].GetComponent<InventorySlotUI>();
            if (i < Inventory.Instance.items.Count)
            {
                slotUI.SetItem(Inventory.Instance.items[i]);
            }
            else
            {
                slotUI.ClearSlot();
            }
        }
    }
}
