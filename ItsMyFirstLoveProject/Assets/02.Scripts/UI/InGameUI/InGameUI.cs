using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InGameUI : MonoBehaviour
{
    [SerializeField] private List<GameObject> _uiList = new List<GameObject>();
    private Dictionary<string, GameObject> _uiDic = new Dictionary<string, GameObject>();

    [SerializeField] private CharacterCommunicationUI _charCommunicationUI;
    [SerializeField] private StartEndPointUI _endPointUI;
    [SerializeField] private StartEndPointUI _startPointUI;
    [SerializeField] private PopUpUI _popUpUI;
    [SerializeField] private VPSUI _vpsUI;
    [SerializeField] private OptionUI _optionUI;

    private void Start() 
    {
        for(int i = 0; i < _uiList.Count; i++)
        {
            _uiList[i].SetActive(false);
            _uiDic.Add(_uiList[i].name, _uiList[i]);
        }

        CheckNowScene();
        //GameManager.Instance.SetObjectProperty("Map", gameObject);
    }

    /// <summary>
    /// 대화UI창 활성화
    /// </summary>
    public void CommuUI()
    {
        ActUI("CharacterCommunicationUI");
    }

    /// <summary>
    /// 대화UI창 내용 추가 <br/>
    /// name : 대화창 이름 <br/>
    /// talk : 대화 내용 
    /// </summary>
    public void AddCommuTalk(string name, string talk)
    {
        _charCommunicationUI.AddTalk(name, talk);
    }

    /// <summary>
    /// 선택지 UI창 내용 추가 <br/>
    /// name : 대화창 이름 <br/>
    /// talk : 대화 내용 <br/>
    /// button1 : 첫 번째 버튼 텍스트 <br/>
    /// button2 : 두 번째 버튼 텍스트 <br/>
    /// </summary>
    public void AddCommuSelect(string name, string talk, string button1, string button1result, string button2, string button2result)
    {
        _charCommunicationUI.AddSelection(name, talk, button1, button1result, button2, button2result);
    }

    /// <summary>
    /// 선택지 UI창 내용 추가 <br/>
    /// name : 대화창 이름 <br/>
    /// talk : 대화 내용 <br/>
    /// button1 : 첫 번째 버튼 텍스트 <br/>
    /// button2 : 두 번째 버튼 텍스트 <br/>
    /// button3 : 세 번째 버튼 텍스트 <br/>
    /// </summary>
    public void AddCommuSelect(string name, string talk, string button1, string button1result, string button2, string button2result, string button3, string button3result)
    {
        _charCommunicationUI.AddSelection(name, talk, button1, button1result, button2, button2result, button3, button3result);
    }

    /// <summary>
    /// 애니메이션 이름 추가 <br/>
    /// animationName : 애니메이션 이름
    /// </summary>
    public void AddAnimationWithTalk(string animationName)
    {
        _charCommunicationUI.AddAnimaition(animationName);
    }

    /// <summary>
    /// VPS 이펙트 추가 함수
    /// </summary>
    /// <param name="vpsIndex"></param>
    public void AddVPSEffectWithTalk(int vpsIndex)
    {
        _charCommunicationUI.AddVPSEffect(vpsIndex);
    }

    /// <summary>
    /// 현재 위치 vps 로케이션 세팅 함수
    /// </summary>
    /// <param name="location"></param>
    public void SetCurrentLocationInGameUI(LocationEventSystem location)
    {
        _charCommunicationUI.SetCurrentLocation(location);
    }

    /// <summary>
    /// EndPointUI 호출 함수 <br/>
    /// coment : 안내 메세지 <br/>
    /// name : 상호명 <br/>
    /// location : 주소 <br/>
    /// </summary>
    public void EndPoint(string comment, string name, string location)
    {
        ActUI("EndPointUI");
        _endPointUI.TextSet(comment, name, location);
    }

    /// <summary>
    /// StartPointUI 호출 함수 <br/>
    /// coment : 안내 메세지 <br/>
    /// name : 상호명 <br/>
    /// location : 주소 <br/>
    /// </summary>
    public void StartPoint(string comment, string name, string location)
    {
        ActUI("StartPointUI");
        _startPointUI.TextSet(comment, name, location);
    }

    /// <summary>
    /// HeightCheck 호출
    /// </summary>
    public void HeightCheck()
    {
        ActUI("HeightCheckUI");
    }

    /// <summary>
    /// HeightCheck 비활성화 및 RotationCheck실행
    /// </summary>
    public void CompleteHeightCheck()
    {
        DeactUI("HeightCheckUI");
        RotationCheck();
    }

    /// <summary>
    /// 지도 회전 UI 출력
    /// </summary>
    public void RotationCheck()
    {
        ActUI("RotationCheckUI");
    }

    public void CompleteRotationCheck()
    {
        DeactUI("RotationCheckUI");
        CheckNowScene();
    }

    private void CheckNowScene()
    {
        if (SceneManager.GetActiveScene().name == "WalkMode")
        {
            ActUI("WalkUI");
            ActUI("NormalUI");
        }
        else if (SceneManager.GetActiveScene().name == "StageMode")
        {
            ActUI("StoryUI");
            ActUI("NormalUI");
        }
    }

    /// <summary>
    /// 팝업 UI 출력 <br/>
    /// Text : 팝업창에 출력할 텍스트 입력
    /// </summary>
    public void PopUp(string Text)
    {
        ActUI("PopUpUI");
        _popUpUI.SetText(Text);
    }

    /// <summary>
    /// VPS 연출 종료 UI 출력 <br/>
    /// effect : VPS 오브젝트
    /// </summary>
    public void VPSUI(GameObject effect)
    {
        ActUI("VPSUI");
        _vpsUI.EffectObjectSet(effect);
    }

    /// <summary>
    /// 일시정지 UI 호출
    /// </summary>
    public void Pause()
    {
        ActUI("PauseUI");
    }

    /// <summary>
    /// Normal UI 호출
    /// </summary>
    public void Normal()
    {
        ActUI("NormalUI");
    }

    /// <summary>
    /// Inventory UI 호출
    /// </summary>
    public void Inventory()
    {
            ActUI("InventoryUI");
    }

    /// <summary>
    /// Inventory 닫기
    /// </summary>
    public void CloseInventory()
    {
        DeactUI("InventoryUI");
    }

    /// <summary>
    /// 산책모드 UI 호출
    /// </summary>
    public void Walk()
    {
        ActUI("WalkUI");
    }

    /// <summary>
    /// 환경설정 UI 호출, 매개변수로 호출하는 씬의 오브젝트 담아서 호출함
    /// </summary>
    public void Option(GameObject UI)
    {
        ActUI("OptionUI");
        _optionUI.ObjectSet(UI);
    }

    private void ActUI(string ui)
    {
        _uiDic[ui].SetActive(true);
    }

    private void DeactUI(string ui)
    {
        _uiDic[ui].SetActive(false);
    }
}
