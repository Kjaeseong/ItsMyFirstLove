using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class ItemsPanel : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _nameText;
    [SerializeField] private TextMeshProUGUI _itemInfoText;
    [SerializeField] private TextMeshProUGUI _cooldownText;
    [SerializeField] private GameObject _itemPanel;

    private Items _nowSelectItem;
    private int _time = 0;

    [SerializeField] private Inventory _inven;

    private void OnEnable()
    {
        GameManager.Instance.ItemInfo.AddListener(ShowItemPanel);
    }

    private void ShowItemPanel(Items item)
    {
        _itemPanel.SetActive(true);
        _nowSelectItem = item;
        Debug.Log($"{_nowSelectItem.ItemName}");
        _nameText.text = $"Name : {item.ItemName}";
        _itemInfoText.text = item.ItemInfo;
    }

    /// <summary>
    /// �г� ������ư Ŭ���� ȣ��� �Լ�
    /// </summary>
    public void ClosePanel()
    {
        _itemPanel.SetActive(false);
    }

    public void GetItemButtonClick()
    {
        _inven.AddItem(_nowSelectItem);
        StartCoroutine(CooldownCheck(_nowSelectItem));
    }

    IEnumerator CooldownCheck(Items item)
    {
        while (item.ItemGetCooldown - _time > 0)
        {
            _cooldownText.text = $"{item.ItemGetCooldown - _time} Sec remain";
            yield return new WaitForSecondsRealtime(1f);
            ++_time;
        }
        _time = 0;
        _cooldownText.text = "";
    }

    private void OnDisable()
    {
        GameManager.Instance.ItemInfo.RemoveListener(ShowItemPanel);
    }
}
