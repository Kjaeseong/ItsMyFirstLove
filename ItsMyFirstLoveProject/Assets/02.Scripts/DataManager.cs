using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    public Items[] InventoryData { get; private set; }
    public int Favorability { get; private set; }
    public int Level { get; private set; }

    private void Awake()
    {
        Favorability = 0;
        Level = 1;
        InventoryData = new Items[8];
    }

    public Items[] LoadInvenData()
    {
        return InventoryData;
    }

    public void SaveInvenData(Items[] PlayerInventory)
    {
        InventoryData = PlayerInventory;
    }

    public void SaveCharacterData(int favor, int level)
    {
        Favorability = favor;
        Level = level;
    }
}
