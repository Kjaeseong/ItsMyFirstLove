using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeRandScript : MonoBehaviour
{
    //�ٲ� �ؽ�Ʈ ������Ʈ
    [SerializeField] private Animator _characterAnimation;
    [SerializeField] private Text        _changeText;
    [SerializeField] private GameObject  _textBar;

    [SerializeField] private string[]    _clickScripts;
    [SerializeField] private string[]    _timeChangeScripts;

    private FadeOutScript _fadeOutScript;


    private int         _randNum;
    private float _coolTime = 20f;
    private float _nowTime = 0f;

    private void Start() 
    {
        _fadeOutScript = GetComponentInChildren<FadeOutScript>();
    }

    private void Update()
    {
        if(_nowTime > _coolTime)
        {
            CallTextBoxInTime();
        }
        else
        {
            _nowTime += Time.deltaTime;
        }
    }

    /// <summary>
    /// ��ư Ŭ���� ���� �Լ�
    /// </summary>
    public void BackGroundTouch()
    {
        TextChangerClick();
        AnimChange(Random.Range(0, 2));
        _fadeOutScript.OnclickFadeOut();
        _textBar.SetActive(true);
    }

    private void TextChangerClick()
    {
        _randNum = Random.Range(0, _clickScripts.Length);
        _changeText.text = _clickScripts[_randNum];
        _nowTime = 0;
    }

    //20�ʿ� �ѹ��� ���
    private void CallTextBoxInTime()
    {
        _randNum = Random.Range(0, _timeChangeScripts.Length);
        _changeText.text = _timeChangeScripts[_randNum];
        _fadeOutScript.OnclickFadeOut();
        _nowTime = 0;
    }

    private void AnimChange(int num)
    {
        switch(num)
        {
            case 0:
                _characterAnimation.SetTrigger("KISS");
                break;
            case 1:
                _characterAnimation.SetTrigger("NO");
                break;
        }
    }
}
