using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    public Items[] InventoryData { get; private set; }

    public Items[] LoadInvenData()
    {
        return InventoryData;
    }

    public void SaveInvenData(Items[] PlayerInventory)
    {
        InventoryData = PlayerInventory;
    }
}
