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
    /// TalkBox 활성화
    /// Text : Box 내 표기할 텍스트 입력
    /// </summary>
    public void ActivateTalkBox(string Text)
    {
        _talkBoxText.text = Text;
        _talkBox.SetActive(true);
    }

    /// <summary>
    /// 챕터 선택창UI 출력
    /// </summary>
    public void ActivateChapterSelect()
    {
        _title.ActivateChapterSelect();
    }

    /// <summary>
    /// 산책모드 실행
    /// </summary>
    public void PlayWalkMode()
    {
        GameManager.Instance._scene.Change("WalkMode");
    }

    /// <summary>
    /// 환경설정UI 출력
    /// </summary>
    public void ActivateOption()
    {
        _title.ActivateOption();
    }


    /// <summary>
    /// TalkBox 비활성화시 동작
    /// </summary>
    public void OnDisableBox()
    {
        StartCoroutine(ActivateBoxAuto());
    }

    /// <summary>
    /// 배경화면 클릭시 TalkBox 활성화 로직
    /// </summary>
    public void ActivateBoxTouch()
    {
        StopCoroutine(ActivateBoxAuto());
        ActivateTalkBox(_BoxText[Random.Range(0, _BoxText.Count)]);
        _talkBox.SetActive(true);
    }

    private void CharacterTouch()
    {
        ActivateTalkBox(_BoxText[Random.Range(0, _BoxText.Count)]);
        // TODO : 케릭터 애니메이션 실행 로직 추가해야함.
    }
    
    private IEnumerator ActivateBoxAuto()
    {
        yield return new WaitForSeconds(_actBoxTextTime);
        ActivateTalkBox(_BoxText[Random.Range(0, _BoxText.Count)]);
        _talkBox.SetActive(true);
    }
}
