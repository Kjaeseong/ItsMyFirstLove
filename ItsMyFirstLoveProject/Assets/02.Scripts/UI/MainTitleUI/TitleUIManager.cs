using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleUIManager : MonoBehaviour
{
    private GameObject _modeSelectUI;
    private ModeSelectUI _modeSelectUIscript;

    private GameObject _chapterSelectUI;
    private ChapterSelectUI _chapterSelectUIscript;

    private GameObject _optionUI;
    private KJS_OptionUI _optionUIscript;

    private GameObject _mainTitleUI;
    private MainTitleUI _mainTitleUIscript;

    private void Start() 
    {
        _modeSelectUIscript = GetComponentInChildren<ModeSelectUI>();
        _modeSelectUI = _modeSelectUIscript.gameObject;

        _chapterSelectUIscript = GetComponentInChildren<ChapterSelectUI>();
        _chapterSelectUI = _chapterSelectUIscript.gameObject;
        
        _optionUIscript = GetComponentInChildren<KJS_OptionUI>();
        _optionUI = _optionUIscript.gameObject;

        _mainTitleUIscript = GetComponentInChildren<MainTitleUI>();
        _mainTitleUI = _mainTitleUIscript.gameObject;

        _mainTitleUI.SetActive(false);
        _optionUI.SetActive(false);
        _chapterSelectUI.SetActive(false);

        //테스트 용도
        ActivateMainTitle();
    }

    private void ActivateLoading()
    {
        
    }

    private void ActivateMainTitle()
    {
        _mainTitleUI.SetActive(true);
    }

    /// <summary>
    /// 모드 선택창UI 출력
    /// </summary>
    public void ActivateModeSelect()
    {
        _modeSelectUI.SetActive(true);
    }

    /// <summary>
    /// 챕터 선택창UI 출력
    /// </summary>
    public void ActivateChapterSelect()
    {
        _chapterSelectUI.SetActive(true);
        _chapterSelectUIscript.BackMenuObjectSet(_modeSelectUI);
        _modeSelectUI.SetActive(false);
    }

    /// <summary>
    /// 환경설정UI 출력
    /// </summary>
    public void ActivateOption()
    {
        _optionUI.SetActive(true);
        _optionUIscript.BackMenuObjectSet(_modeSelectUI);
    }

    /// <summary>
    /// 스테이지 정보 창 활성화
    /// </summary>
    public void ActivateStageDescription()
    {
        // 혹시 모를 스테이지 시작 전 정보창을 띄우기 위한 함수.
    }
}
