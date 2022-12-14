using Google.Maps.Examples;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OpenChapter : MonoBehaviour
{
    //일정 호감도 레벨 달성 및 이전 챕터 클리어시 현재 챕터 오픈

    public bool         isClear;
    //레벨 가져오기
    public UIManager    PlayerLv;
    //챕터 오픈가능한 레벨
    public int          OpenLv;
    //위치값 변환하기 위해 가져옮
    public Text         ChapterText;
    //텍스트 Info 삭제하기
    public Text         NonOpenTextInfo;
    //백그라운드
    public Image        ChapterBack;
    //버튼 활성화
    private Button _chapterButton;

    private void Start()
    {
        _chapterButton = GetComponent<Button>();
    }
    private void Update()
    {
        InteractiveChpater();
    }
    
    private void InteractiveChpater()
    {
        if (isClear && PlayerLv.Level >= OpenLv)
        {
            Destroy(NonOpenTextInfo);
            ChapterText.rectTransform.localPosition = new Vector3(0, 0, 0);
            ChapterBack.color = new Color(255, 255, 0);
            _chapterButton.interactable = true;
        }
    }

}
