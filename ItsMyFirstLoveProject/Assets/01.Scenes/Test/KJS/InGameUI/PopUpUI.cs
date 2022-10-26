using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PopUpUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;
    [SerializeField] private float _deactivateTime;

    private void OnEnable() 
    {
        StartCoroutine(Deactivate());
    }

    /// <summary>
    /// 텍스트 변경을 위한 함수. 매개변수로 입력된 텍스트 출력
    /// </summary>
    public void SetText(string Text)
    {
        _text.text = Text;
    }

    private IEnumerator Deactivate()
    {
        yield return new WaitForSeconds(_deactivateTime);
        gameObject.SetActive(false);
    }
}
