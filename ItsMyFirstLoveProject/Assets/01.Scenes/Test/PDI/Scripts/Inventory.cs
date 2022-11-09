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
    /// �������� ȹ���� �ڿ� �κ��丮�� �߰��ϴ� �Լ�
    /// </summary>
    /// <param name="item">item ��ũ��Ʈ�� �ִ� item����</param>
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
    /// ���ӸŴ����� �ִ� �κ��丮 Load
    /// </summary>
    public void LoadInventory()
    {
        ItemInInventory = GameManager.Instance._dataMgr.LoadInvenData();
    }

    /// <summary>
    /// �κ��丮�� ���ӸŴ����� Save
    /// </summary>
    public void SaveInventory()
    {
        GameManager.Instance._dataMgr.SaveInvenData(ItemInInventory);
    }
}