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

    private Inventory _inven;

    private void Start()
    {
        _inven = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
    }
    private void OnEnable()
    {
        GameManager.Instance.ItemInfo.AddListener(ShowItemPanel);
    }

    private void ShowItemPanel(Items item)
    {
        _itemPanel.SetActive(true);
        _nowSelectItem = item;
        _nameText.text = item.ItemName.ToString();
        _itemInfoText.text = item.ItemInfo;
        _cooldownText.text = item.ItemGetCooldown.ToString();
        StartCoroutine(CooldownCheck(item));
    }

    /// <summary>
    /// 패널 닫힘버튼 클릭시 호출될 함수
    /// </summary>
    public void ClosePanel()
    {
        _itemPanel.SetActive(false);
    }

    public void GetItemButtonClick()
    {
        _inven.AddItem(_nowSelectItem);
    }

    IEnumerator CooldownCheck(Items item)
    {
        while (item.ItemGetCooldown - _time > 0)
        {
            yield return new WaitForSecondsRealtime(1f);
            ++_time;
            _cooldownText.text = (item.ItemGetCooldown - _time).ToString();
        }
        _time = 0;
    }

    private void OnDisable()
    {
        GameManager.Instance.ItemInfo.RemoveListener(ShowItemPanel);
    }
}
