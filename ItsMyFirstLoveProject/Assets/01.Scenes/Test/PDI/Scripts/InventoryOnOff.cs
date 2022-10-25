using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryOnOff : MonoBehaviour
{
    [SerializeField] GameObject _inventoryButton;
    [SerializeField] GameObject _inventoryUI;

    public void OpenInventory()
    {
        _inventoryButton.SetActive(false);
        _inventoryUI.SetActive(true);
    }

    public void CloseInventory()
    {
        _inventoryButton.SetActive(true);
        _inventoryUI.SetActive(false);
    }
}
