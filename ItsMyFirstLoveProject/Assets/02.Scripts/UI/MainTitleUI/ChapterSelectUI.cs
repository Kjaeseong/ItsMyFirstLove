using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChapterSelectUI : MonoBehaviour
{
    [SerializeField] private GameObject _backMenu;
    [SerializeField] private GameObject _chapterList;
    [SerializeField] private GameObject _chapterInfoUI;
    [SerializeField] private ChapterInfoUI _chapterInfoUIscript;


    private void Start() 
    {
        _chapterInfoUIscript = GetComponentInChildren<ChapterInfoUI>();
        _chapterInfoUI = _chapterInfoUIscript.gameObject;
        _chapterInfoUI.SetActive(false);
    }

    public void BackButton()
    {
        _backMenu.SetActive(true);
        gameObject.SetActive(false);
    }

    public void ActivateChapterInfo(int ChapterNumber, string StartPosition, string PlaceName, string Location, string Story)
    {
        _chapterInfoUI.SetActive(true);
        _chapterInfoUIscript.BackMenuObjectSet(_chapterList);
        _chapterList.SetActive(false);

        _chapterInfoUIscript.ChapterNumber = ChapterNumber;
        _chapterInfoUIscript.StartPosition = StartPosition;
        _chapterInfoUIscript.PlaceName = PlaceName;
        _chapterInfoUIscript.Location = Location;
        _chapterInfoUIscript.Story = Story;
    }

    public void BackMenuObjectSet(GameObject BackMenu)
    {
        _backMenu = BackMenu;
    }
}
