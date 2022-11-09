using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    [SerializeField] Button[] _button;
    [SerializeField] GameObject[] _panel;
    [SerializeField] Inventory _inven;
    [SerializeField] GameObject _hanaChan;

    private Character _character;

    private bool _showPanel = false;

    private void Awake()
    {
        _character = _hanaChan.GetComponent<Character>();
    }

    private void Start()
    {
        for (int i = 0; i < _panel.Length; ++i)
        {
            _panel[i].SetActive(false);
        }
    }

    private void Update()
    {
        CheckInventory();
    }

    private void CheckInventory()
    {
        for (int i = 0; i < _inven.ItemInInventory.Length; ++i)
        {
            if (_inven.ItemInInventory[i] == null)
            {
                _button[i].gameObject.SetActive(false);
            }
            else
            {
                _button[i].gameObject.SetActive(true);

                Text _text = _button[i].GetComponentInChildren<Text>();
                _text.text = _inven.ItemInInventory[i].ItemCount.ToString();

                Image _image = _button[i].GetComponent<Image>();
                _image.sprite = _inven.ItemInInventory[i].ItemImage.sprite;
            }
        }
    }

    /// <summary>
    /// 아이템 사용 함수
    /// </summary>
    /// <param name="index">인벤토리 내부에 존재하는 아이템의 Index</param>
    public void UseItem(int index)
    {
        if (_inven.ItemInInventory[index].ItemCount >= 1)
        {
            --_inven.ItemInInventory[index].ItemCount;
            _character.ReceivePresent(_inven.ItemInInventory[index].Impression);
        }

        if(_inven.ItemInInventory[index].ItemCount == 0)
        {
            _inven.ItemInInventory[index] = null;
        }

    }

    /// <summary>
    /// 아이템 삭제 함수
    /// </summary>
    /// <param name="index">인벤토리 내부에 존재하는 아이템의 Index</param>
    public void DeleteItem(int index)
    {
        if (_inven.ItemInInventory[index].ItemCount >= 1)
        {
            --_inven.ItemInInventory[index].ItemCount;
        }

        if (_inven.ItemInInventory[index].ItemCount == 0)
        {
            _inven.ItemInInventory[index] = null;
        }
    }

    /// <summary>
    /// 아이템 사용/삭제 패널을 띄우기 위한 함수
    /// </summary>
    /// <param name="index">아이템 사용/삭제 패널을 띄우기 위한 index</param>
    public void ShowPanel(int index)
    {
        _showPanel = !_showPanel;
        _panel[index].SetActive(_showPanel);
    }
}
