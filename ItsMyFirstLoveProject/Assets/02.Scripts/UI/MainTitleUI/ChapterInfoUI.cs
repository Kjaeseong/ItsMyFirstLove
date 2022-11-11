using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ChapterInfoUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _chapterNumber;
    [SerializeField] private TextMeshProUGUI _startPosition;
    [SerializeField] private TextMeshProUGUI _placeName;
    [SerializeField] private TextMeshProUGUI _location;
    [SerializeField] private TextMeshProUGUI _story;

    public int ChapterNumber{ get; set; }
    public string StartPosition { get; set; }
    public string PlaceName { get; set; }
    public string Location { get; set; }
    public string Story { get; set; }

    private GameObject _backMenu;
    private GameObject PopUpUI;

    // 시작 범위 내 들어가 있는지 판별하기 위한 bool타입 변수
    // 테스트 종료시 SerializeField 삭제
    [SerializeField] private bool _insideStartArea;

    private void Start() 
    {
        PopUpUI = GetComponentInChildren<ChapterInfoPopUpUI>().gameObject;
        PopUpUI.SetActive(false);
        
    }
    
    private void OnEnable() 
    {
        SetText();
    }

    private void SetText()
    {
        _chapterNumber.text = $"Chapter {ChapterNumber}";
        _startPosition.text = StartPosition;
        _placeName.text = PlaceName;
        _location.text = Location;
        _story.text = Story;
    }

    public void StartButton()
    {
        if(_insideStartArea)
        {
            GameManager.Instance._scene.Change("StoryMode");
        }
        else
        {
            PopUpUI.SetActive(true);
        }
    }

    public void MapScaleUpButton()
    {
        // TODO : 지도 확대버튼 클릭시 동작 로직 넣어야 함. 박도일팀장 등원시 공동작업 예정
    }

    public void BackMenuObjectSet(GameObject BackMenu)
    {
        _backMenu = BackMenu;
    }

    public void BackButton()
    {
        _backMenu.SetActive(true);
        gameObject.SetActive(false);
    }
}
