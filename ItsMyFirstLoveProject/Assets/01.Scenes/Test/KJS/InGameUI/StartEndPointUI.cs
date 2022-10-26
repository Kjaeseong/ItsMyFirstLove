using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StartEndPointUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _coment;
    [SerializeField] private TextMeshProUGUI _name;
    [SerializeField] private TextMeshProUGUI _location;

    /// <summary>
    /// 텍스트 세팅을 위한 함수 <br/>
    /// coment : 안내 메세지 <br/>
    /// name : 상호명 <br/>
    /// location : 주소 <br/>
    /// </summary>
    public void TextSet(string coment, string name, string location)
    {
        _coment.text = coment;
        _name.text = name;
        _location.text = location;
    }
    
    /// <summary>
    /// 비활성화시 실행 함수
    /// </summary>
    public void DeactivateUI()
    {
        // 특정 이벤트 발생해야 한다면 여기에 추가
        gameObject.SetActive(false);
    }
}
