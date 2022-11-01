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
    [field: SerializeField] public float DeactBoxTextTime { get; private set; }
    [SerializeField] private float _actBoxTextTime;
    private TitleUIManager _title;
    private TextMeshProUGUI _talkBoxText;
    private List<string> _BoxText = new List<string>();

    private void Start() 
    {
        _title = GetComponentInParent<TitleUIManager>();
        _talkBoxText = _talkBox.GetComponentInChildren<TextMeshProUGUI>();
    }
    
    /// <summary>
    ///
    /// </summary>
    public void PlayWalkMode()
    {
        _title.PlayWalkMode();
    }


    /// <summary>
    /// 
    /// </summary>
    public void ActivateTalkBox(string Text)
    {
        _talkBoxText.text = Text;
        _talkBox.SetActive(true);
    }

    /// <summary>
    ///
    /// </summary>
    public void ActivateChapterSelect()
    {
        _title.ActivateChapterSelect();
    }

    /// <summary>
    ///
    /// </summary>
    public void PlayWalkMode()
    {
        _title.PlayWalkMode();
    }

    /// <summary>
    ///
    /// </summary>
    public void ActivateOption()
    {
        _title.ActivateOption();
    }

    private void CharacterTouch()
    {
        ActivateTalkBox(_BoxText[Random.Range(0, _BoxText.Count)]);
    }

    private IEnumerator ActivateBoxAuto()
    {
        yield return new WaitForSeconds(_actBoxTextTime);
        ActivateTalkBox(_BoxText[Random.Range(0, _BoxText.Count)]);
        _talkBox.SetActive(true);
    }

    public void ActivateBoxTouch()
    {
        ActivateTalkBox(_BoxText[Random.Range(0, _BoxText.Count)]);
        _talkBox.SetActive(true);
    }

}
