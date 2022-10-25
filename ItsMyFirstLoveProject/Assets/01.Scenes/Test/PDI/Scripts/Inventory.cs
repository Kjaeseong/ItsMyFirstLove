using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Inventory : MonoBehaviour
{
    public Items[] ItemInInventory { get; private set; }

    void Awake()
    {
        ItemInInventory = new Items[8];
    }

    public void AddItem(Items item)
    {
        for (int i = 0; i < ItemInInventory.Length; ++i)
        {
            if (ItemInInventory[i] == null)
            {
                ItemInInventory[i] = item;
                ++ItemInInventory[i].ItemCount;
                return;
            }

            else if (item.ItemName == ItemInInventory[i].ItemName)
            {                                                           
                ++ItemInInventory[i].ItemCount;
                return;
            }
        }

        Debug.Log("인벤토리 가득 참");
    }
}