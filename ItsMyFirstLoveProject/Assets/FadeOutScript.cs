using Google.Protobuf.WellKnownTypes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeOutScript : MonoBehaviour
{
    public int EnableTextBarTime = 3;

    private Color _c;
    //알파값 20%
    private float _colorA = 0.2f;
    private Coroutine _startFadeOut;

    //활성화시 3초후 페이드 아웃

    private void Start()
    {
        _c = this.gameObject.GetComponent<Image>().color;
        StartCoroutine("FadeOut");
    }
    private void OnEnable()
    {
        _c.a = _colorA;
    }

    public IEnumerator FadeOut()
    {
        yield return new WaitForSeconds(EnableTextBarTime);
        for (float f = 1f; f > 0; f -= 0.003f)
            {

                _c.a = (f * _colorA);
                this.GetComponent<Image>().color = _c;
                yield return null;
                Debug.Log("A");
            }
            this.gameObject.SetActive(false);
            this.GetComponent<Image>().color = new Color(0, 0, 0, 0.2f);
    }

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
