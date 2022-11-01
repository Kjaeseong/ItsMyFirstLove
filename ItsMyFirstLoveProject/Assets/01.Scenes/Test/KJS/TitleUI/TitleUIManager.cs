using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleUIManager : MonoBehaviour
{
    [SerializeField] private GameObject _modeSelectUI;
    [SerializeField] private GameObject _chapterSelectUI;
    [SerializeField] private GameObject _optionUI;


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
    }

    /// <summary>
    /// 환경설정UI 출력
    /// </summary>
    public void ActivateOption()
    {
        _optionUI.SetActive(true);
    }

    /// <summary>
    /// 스테이지모드 씬 실행
    /// </summary>
    public void PlayStageMode()
    {
        GameManager.Instance._scene.Change("StageMode");
    }

    /// <summary>
    /// 스테이지 정보 창 활성화
    /// </summary>
    public void ActivateStageDescription()
    {
        // 혹시 모를 스테이지 시작 전 정보창을 띄우기 위한 함수.
    }
}
