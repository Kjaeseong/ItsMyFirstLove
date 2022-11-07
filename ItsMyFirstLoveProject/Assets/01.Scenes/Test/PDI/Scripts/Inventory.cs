using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Inventory : MonoBehaviour
{
    public Items[] ItemInInventory { get; private set; }

    private void Start()
    {
        LoadInventory();
    }

    /// <summary>
    /// 아이템을 획득한 뒤에 인벤토리에 추가하는 함수
    /// </summary>
    /// <param name="item">item 스크립트에 있는 item정보</param>
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
    }

    /// <summary>
    /// 게임매니저에 있는 인벤토리 Load
    /// </summary>
    public void LoadInventory()
    {
        ItemInInventory = GameManager.Instance._dataMgr.LoadInvenData();
    }

    /// <summary>
    /// 인벤토리를 게임매니저에 Save
    /// </summary>
    public void SaveInventory()
    {
        GameManager.Instance._dataMgr.SaveInvenData(ItemInInventory);
    }
}