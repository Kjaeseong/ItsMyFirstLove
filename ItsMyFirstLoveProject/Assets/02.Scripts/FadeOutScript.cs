using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeOutScript : MonoBehaviour
{
    // 3초후 페이드 아웃
    public int EnableTextBarTime = 3;

    private Color _color;
    //알파값 20%
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
                Debug.Log("페이드아웃");
            }
            this.gameObject.SetActive(false);
            this.GetComponent<Image>().color = new Color(0, 0, 0, 0.2f);
    }
    //코루틴 실행중 한번 더 클릭 시 멈추고 다시 실행 
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
