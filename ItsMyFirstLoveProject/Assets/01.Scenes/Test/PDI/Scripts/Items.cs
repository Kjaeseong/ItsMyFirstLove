using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Items : MonoBehaviour
{
    public string ItemName { get; private set; }
    public int ItemCount { get; set; }
    public int Impression { get; set; }
    // TODO: Impresstion �߰�
    public string ItemInfo { get; private set; }
    // TODO: ������ ���� �߰�
    public Image ItemImage { get; private set; }
    public int ItemGetCooldown { get; private set; }
    //TODO: ������ ȹ�� ��Ÿ�� �߰�(���� int ��)

    // Start is called before the first frame update
    void Start()
    {
        ItemName = gameObject.name;
        ItemCount = 0;
        ItemImage = GetComponent<Image>();
    }
}
