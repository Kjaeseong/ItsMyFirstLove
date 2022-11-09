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

    // 팝업창 띄워야됨
    
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
        GameManager.Instance._scene.Change("StoryMode");
    }

    public void MapScaleUpButton()
    {
        // 지도 확대버튼 클릭시 동작
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
