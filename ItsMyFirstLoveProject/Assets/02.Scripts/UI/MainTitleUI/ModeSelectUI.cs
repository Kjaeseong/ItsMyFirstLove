using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ModeSelectUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _hadCoinText;
    [SerializeField] private TextMeshProUGUI _levelText;
    [SerializeField] private Image _favorabilityGauge;
    [SerializeField] private GameObject _talkBox;
    
    // TalkBox 활성화 시 비활성화까지의 시간
    [field: SerializeField] public float DeactBoxTextTime { get; private set; }
    // TalkBox 비활성화 상태시 자동으로 활성화되는 시간
    [SerializeField] private float _actBoxTextTime;

    private TitleUIManager _title;
    private TextMeshProUGUI _talkBoxText;
    private List<string> _boxText = new List<string>();

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
        //ActivateTalkBox(_boxText[Random.Range(0, _boxText.Count)]);
        _talkBox.SetActive(true);
    }

    /// <summary>
    /// BoxTextList에 미리 텍스트를 추가하기 위한 함수
    /// Text : 입력할 텍스트 입력
    /// </summary>
    public void AddBoxText(string Text)
    {
        _boxText.Add(Text);
    }

    /// <summary>
    /// 보유 코인 Text 갱신
    /// Text : 입력할 텍스트 입력
    /// </summary>
    public void CoinTextSet(string Text)
    {
        _hadCoinText.text = Text;
    }

    /// <summary>
    /// 레벨 Text 갱신
    /// Text : 입력할 텍스트 입력
    /// </summary>
    public void LevelTextSet(string Text)
    {
        _levelText.text = Text;
    }

    /// <summary>
    /// 호감도 게이지 갱신
    /// value : 호감도 값
    /// </summary>
    public void FavorabilityGaugeSet(float value)
    {
        // TODO : 추후 게이지 최대치 혹은 적용값 기획 변경시 수정해야 할 로직
        _favorabilityGauge.fillAmount = value / 100;
    }

    /// <summary>
    /// 배경화면 클릭시 동작
    /// </summary>
    public void BackGroundTouch()
    {
        //ActivateTalkBox(_boxText[Random.Range(0, _boxText.Count)]);
        _talkBox.SetActive(true);
        StopCoroutine(ActivateBoxAuto());
        // TODO : 케릭터 애니메이션 실행 로직 추가해야함.
    }

    private IEnumerator ActivateBoxAuto()
    {
        yield return new WaitForSeconds(_actBoxTextTime);
        //ActivateTalkBox(_boxText[Random.Range(0, _boxText.Count)]);
        _talkBox.SetActive(true);
    }
}
