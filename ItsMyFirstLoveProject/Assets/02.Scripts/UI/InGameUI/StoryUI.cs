using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryUI : MonoBehaviour
{
    private InGameUI _inGameUI;

    private void Start()
    {
        _inGameUI = GetComponentInParent<InGameUI>();
    }

    /// <summary>
    /// InGameUI�� �κ��丮 Ȱ��ȭ �Լ� ȣ�� 
    /// </summary>
    public void ActivateInventory()
    {
        _inGameUI.Inventory();
    }
}
