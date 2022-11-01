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
    /// InGameUI의 인벤토리 활성화 함수 호출 
    /// </summary>
    public void ActivateInventory()
    {
        _inGameUI.Inventory();
    }
}
