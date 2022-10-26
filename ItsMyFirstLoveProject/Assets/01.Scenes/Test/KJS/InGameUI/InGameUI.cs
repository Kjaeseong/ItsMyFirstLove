using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameUI : MonoBehaviour
{
    [SerializeField] private List<GameObject> _uiList = new List<GameObject>();
    private Dictionary<string, GameObject> _uiDic = new Dictionary<string, GameObject>();

    [SerializeField]private CharacterCommunicationUI _charCommunicationUI;
    [SerializeField]private StartEndPointUI _endPointUI;
    [SerializeField]private StartEndPointUI _startPointUI;
    [SerializeField]private HeightCheckUI _heightChecker;
    [SerializeField]private RotationCheckUI _rotationCheckUI;
    [SerializeField]private PopUpUI _popUpUI;
    [SerializeField]private VPSUI _vpsUI;

    private void Start() 
    {
        for(int i = 0; i < _uiList.Count; i++)
        {
            _uiList[i].SetActive(false);
            _uiDic.Add(_uiList[i].name, _uiList[i]);
        }
    }

    private void Update() 
    {
        ActUI("PopUpUI");
    }

    public void Communication()
    {

    }

    /// <summary>
    /// EndPointUI 호출 함수 <br/>
    /// coment : 안내 메세지 <br/>
    /// name : 상호명 <br/>
    /// location : 주소 <br/>
    /// </summary>
    public void EndPoint(string comment, string name, string location)
    {
        _endPointUI.TextSet(comment, name, location);
        _uiDic["EndPointUI"].SetActive(true);
    }

    /// <summary>
    /// StartPointUI 호출 함수 <br/>
    /// coment : 안내 메세지 <br/>
    /// name : 상호명 <br/>
    /// location : 주소 <br/>
    /// </summary>
    public void StartPoint(string comment, string name, string location)
    {
        _startPointUI.TextSet(comment, name, location);
        _uiDic["StartPointUI"].SetActive(true);
    }

    public void HeightCheck()
    {
        
    }

    public void RotationCheck()
    {
        
    }

    public void PopUp()
    {
        
    }

    public void VPSUI()
    {
        
    }

    private void ActUI(string ui)
    {
        _uiDic[ui].SetActive(true);
    }



    






}
