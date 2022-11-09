using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChapterSelectUI : MonoBehaviour
{
    [SerializeField] private GameObject _backMenu;

    private GameObject _chapterInfoUI;
    private ChapterInfoUI _chapterInfoUIscript;

    private void Start() 
    {
        _chapterInfoUIscript = GetComponentInChildren<ChapterInfoUI>();
        _chapterInfoUI = _chapterInfoUIscript.gameObject;
    }

    public void BackButton()
    {
        _backMenu.SetActive(true);
        gameObject.SetActive(false);
    }

    public void ActivateChapterInfo(int ChapterNumber, string StartPosition, string PlaceName, string Location, string Story)
    {
        _chapterInfoUIscript.BackMenuObjectSet(gameObject);

        _chapterInfoUIscript.ChapterNumber = ChapterNumber;
        _chapterInfoUIscript.StartPosition = StartPosition;
        _chapterInfoUIscript.PlaceName = PlaceName;
        _chapterInfoUIscript.Location = Location;
        _chapterInfoUIscript.Story = Story;

        gameObject.SetActive(false);
    }

    public void BackMenuObjectSet(GameObject BackMenu)
    {
        _backMenu = BackMenu;
    }
}
