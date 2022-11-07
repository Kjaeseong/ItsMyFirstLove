using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Items : MonoBehaviour
{
    public string ItemName { get; private set; }
    public int ItemCount { get; set; }
    public int Impression { get; set; }
    // TODO: Impresstion 추가
    public string ItemInfo { get; private set; }
    // TODO: 아이템 정보 추가
    public Image ItemImage { get; private set; }
    public int ItemGetCooldown { get; private set; }
    //TODO: 아이템 획득 쿨타임 추가(단위 int 초)

    // Start is called before the first frame update
    void Start()
    {
        ItemName = gameObject.name;
        ItemCount = 0;
        ItemImage = GetComponent<Image>();
    }
}
