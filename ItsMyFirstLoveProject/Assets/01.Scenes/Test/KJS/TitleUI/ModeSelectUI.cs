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
    private TitleUIManager _title;
    private TextMeshProUGUI _talkBoxText;
    private List<string> _BoxText = new List<string>();

    private void Start() 
    {
        _title = GetComponentInParent<TitleUIManager>();
        _talkBoxText = _talkBox.GetComponentInChildren<TextMeshProUGUI>();
    }
    public void StartWalkMode()
    {
        GameManager.Instance._scene.Change("WalkMode");
    }

    private void CharacterTouch()
    {
        ActivateTalkBox(_BoxText[Random.Range(0, _BoxText.Count)]);
    }

    public void ActivateTalkBox(string Text)
    {
        _talkBoxText.text = Text;
        _talkBox.SetActive(true);
    }

    public void ActivateChapterSelect()
    {
        _title.ActivateChapterSelect();
    }
    
    public void PlayWalkMode()
    {
        _title.PlayWalkMode();
    }

    public void ActivateOption()
    {
        _title.ActivateOption();
    }

}
