using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkBoxUI : MonoBehaviour
{
    private ModeSelectUI _modeSelectUI;
    private float _deactBoxTime;

    private void Awake() 
    {
        _modeSelectUI = GetComponentInParent<ModeSelectUI>();
        _deactBoxTime = _modeSelectUI.DeactBoxTextTime;
    }

    private void OnEnable() 
    {
        StartCoroutine(DeactivateBox());
    }

    private void OnDisable() 
    {
        _modeSelectUI.OnDisableBox();
    }

    private IEnumerator DeactivateBox()
    {
        yield return new WaitForSeconds(_deactBoxTime);
        gameObject.SetActive(false);
    }
}
