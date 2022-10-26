using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeRandScript : MonoBehaviour
{
    //바꿀 텍스트 오브젝트
    [SerializeField]
    private Text        _changeText;
    [SerializeField]
    private GameObject  _textBar;

    [SerializeField]
    private string[]    _clickScripts;

    [SerializeField]
    private string[]    _timeChangeScripts;

    [SerializeField]
    private FadeOutScript _fadeOutScript;

    private int         _randNum;
    private float _coolTime = 20f;
    private float _nowTime = 0f;

    private void Update()
    {
        if(_nowTime > _coolTime )
        {
            CallTextBoxInTime();
            _fadeOutScript.OnclickFadeOut();
            _nowTime = 0;
            Debug.Log(Time.time);
        }
        else
        {
            _nowTime += Time.deltaTime;
        }
    }
    public void TextChangerClick()
    {
        _randNum = Random.Range(0, _clickScripts.Length);
        _changeText.text = _clickScripts[_randNum];
        _nowTime = 0;
    }

    //20초에 한번씩 출력
    private void CallTextBoxInTime()
    {
        _randNum = Random.Range(0, _timeChangeScripts.Length);
        _textBar.SetActive(true);
        _changeText.text = _timeChangeScripts[_randNum];
    }

}
