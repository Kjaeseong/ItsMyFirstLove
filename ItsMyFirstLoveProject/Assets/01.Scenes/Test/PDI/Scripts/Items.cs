using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Items : MonoBehaviour
{
    public string ItemName { get; private set; }
    public int ItemCount { get; set; }
    public int Impression { get; set; }
    public string ItemInfo { get; private set; }
    public Image ItemImage { get; private set; }
    public int ItemGetCooldown { get; private set; }

    // Start is called before the first frame update
    void Awake()
    {
        ItemName = gameObject.name;
        ItemCount = 0;
        ItemImage = GetComponent<Image>();

        // TODO: Impresstion 추가
        // TODO: 아이템 정보 추가
        // TODO: 아이템 획득 쿨타임 추가(단위 int 초)
        // 임시데이터
        Impression = 1;
        ItemInfo = "Normal Sphere.";
        ItemGetCooldown = 30;
    }
}
