using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ModeSelectUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _hadCoin;
    [SerializeField] private TextMeshProUGUI _level;
    [SerializeField] private Image _favorability;
    [SerializeField] private GameObject _talkBox;
    [SerializeField] private GameObject _optionUI;
    [SerializeField] private GameObject _chapterSelectUI;
    private TextMeshProUGUI _talkBoxText;
    private List<string> _BoxText = new List<string>();

    private void Start() 
    {
        _talkBoxText = _talkBox.GetComponentInChildren<TextMeshProUGUI>();
    }

    public void ActivateChapterSelect()
    {
        _chapterSelectUI.SetActive(true);
        gameObject.SetActive(false);
    }

    public void StartWalkMode()
    {
        GameManager.Instance._scene.Change("WalkMode");
    }

    public void ActivateOption()
    {
        _optionUI.SetActive(true);
        gameObject.SetActive(false);
    }

    private void CharacterTouch()
    {
        ActivateTalkBox(_BoxText[Random.Range(0, _BoxText.Count)]);
    }

    private void ActivateTalkBox(string Text)
    {
        _talkBoxText.text = Text;
        _talkBox.SetActive(true);
    }
}
