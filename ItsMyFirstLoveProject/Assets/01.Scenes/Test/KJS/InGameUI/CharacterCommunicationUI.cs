using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CharacterCommunicationUI : MonoBehaviour
{
    [SerializeField] private GameObject _talkCanvas;
    [SerializeField] private GameObject _SelectionCanvas;

    [SerializeField] private TextMeshProUGUI _name;
    [SerializeField] private TextMeshProUGUI _talk;
    [SerializeField] private TextMeshProUGUI _selectionText;
    [SerializeField] private TextMeshProUGUI _selectButton1;
    [SerializeField] private TextMeshProUGUI _selectButton2;

    private bool _isSelection;



    /// <summary>
    /// UI창을 대화 모드로 변경 <br/>
    /// name : 대화창 이름 <br/>
    /// talk : 대화 내용 <br/>
    /// </summary>
    public void TalkSet(string name, string talk)
    {
        _isSelection = false;
        BoxFormChange();

        _name.text = name;
        _talk.text = talk;
    }

    /// <summary>
    /// UI창을 선택 모드로 변경 <br/>
    /// name : 대화창 이름 <br/>
    /// talk : 대화 내용 <br/>
    /// button1 : 첫 번째 버튼 텍스트 <br/>
    /// button2 : 두 번째 버튼 텍스트 <br/>
    /// </summary>
    public void SelectionSet(string name, string talk, string button1, string button2)
    {
        _isSelection = true;
        BoxFormChange();

        _name.text = name;
        _selectionText.text = talk;
        _selectButton1.text = button1;
        _selectButton2.text = button2;
    }

    /// <summary>
    /// 버튼 선택시 버튼에 따라 다른 이벤트 실행을 위한 함수 <br/>
    /// 버튼 이벤트에 1 혹은 2 부여 <br/>
    /// </summary>
    public void SelectButton(int select)
    {
        switch(select)
        {
            case 1:
                // 버튼 1 선택시 이벤트
                break;
            case 2:
                // 버튼 2 선택시 이벤트
                break;
        }
        
    }

    private void BoxFormChange()
    {
        _talkCanvas.SetActive(!_isSelection);
        _SelectionCanvas.SetActive(_isSelection);
    }

}
