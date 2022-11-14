using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VPS_CardEffect : MonoBehaviour
{
    private VPS_Card[] _vpsCard = new VPS_Card[3];
    private int _selectCard;

    private void Start() 
    {
        _vpsCard = GetComponentsInChildren<VPS_Card>();
    }

    /// <summary>
    /// 카드 버튼 클릭시 동작 <br/>
    /// 버튼에 따라 다른 int형 매개변수 입력됨(0 ~ 2)
    /// </summary>
    public void CardButton(int select)
    {
        for(int i = 0; i < _vpsCard.Length; i++)
        {
            _vpsCard[i].ClickCard(select);
        }
    }

    /// <summary>
    /// 이펙트 종료시 호출 함수. 자신 오브젝트 비활성화.
    /// </summary>
    public void EndEffect()
    {
        // TODO : VPS연출 이후 UI출력을 위한 추가로직 필요.
        gameObject.SetActive(false);
    }

}
