using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeOutScript : MonoBehaviour
{
    // 3���� ���̵� �ƿ�
    public int EnableTextBarTime = 3;

    private Color _color;
    //���İ� 20%
    private float _colorA = 0.2f;
    private Coroutine _startFadeOut;


    private void Start()
    {
        _color = this.gameObject.GetComponent<Image>().color;
        StartCoroutine("FadeOut");
    }
    private void OnEnable()
    {
        _color.a = _colorA;
    }

    public IEnumerator FadeOut()
    {
        yield return new WaitForSeconds(EnableTextBarTime);
        for (float f = 1f; f > 0; f -= 0.003f)
            {

                _color.a = (f * _colorA);
                this.GetComponent<Image>().color = _color;
                yield return null;
                Debug.Log("���̵�ƿ�");
            }
            this.gameObject.SetActive(false);
            this.GetComponent<Image>().color = new Color(0, 0, 0, 0.2f);
    }
    //�ڷ�ƾ ������ �ѹ� �� Ŭ�� �� ���߰� �ٽ� ���� 
    public void OnclickFadeOut()
    {
        if (_startFadeOut != null)
        {
            StopCoroutine(_startFadeOut);
            _startFadeOut = null;
        }

        _startFadeOut = StartCoroutine("FadeOut");
    }
}
