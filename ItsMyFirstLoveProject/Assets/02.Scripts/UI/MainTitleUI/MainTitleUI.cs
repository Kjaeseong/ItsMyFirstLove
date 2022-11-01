using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainTitleUI : MonoBehaviour
{
    private TitleUIManager _titleUIManager;

    private void Start() 
    {
        _titleUIManager = GetComponentInParent<TitleUIManager>();
    }

    private void OnEnable() 
    {
        // TODO : 추후 타이틀 활성화시 BGM 재생 용도
        // GameManager.Instance._audio.Play();
    }

    /// <summary>
    /// 터치시 비활성화 동작
    /// </summary>
    public void Deactivate()
    {
        _titleUIManager.ActivateModeSelect();
        gameObject.SetActive(false);
    }
}
