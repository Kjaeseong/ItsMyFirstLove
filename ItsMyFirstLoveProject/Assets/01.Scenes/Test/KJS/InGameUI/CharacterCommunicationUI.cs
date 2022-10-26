using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CharacterCommunicationUI : MonoBehaviour
{
    private enum SlideForm
    {
        Talk,
        Select
    }
    [SerializeField] private GameObject _talkCanvas;
    [SerializeField] private GameObject _SelectionCanvas;

    [SerializeField] private TextMeshProUGUI _name;
    [SerializeField] private TextMeshProUGUI _talk;
    [SerializeField] private TextMeshProUGUI _selectionText;
    [SerializeField] private TextMeshProUGUI _selectButton1;
    [SerializeField] private TextMeshProUGUI _selectButton2;

    private Queue<string> _nameQueue = new Queue<string>();
    private Queue<string> _talkQueue = new Queue<string>();
    private Queue<string> _button1Queue = new Queue<string>();
    private Queue<string> _button2Queue = new Queue<string>();
    private Queue<int> _slide = new Queue<int>();

    private bool _isSelection;

    private void OnEnable() 
    {
        SlideInit();
    }

    public void SlideInit()
    {
        if(_slide.Count <= 0)
        {
            gameObject.SetActive(false);
        }

        int slide = _slide.Dequeue();

        if(slide == (int)SlideForm.Talk)
        {
            _isSelection = false;
            BoxFormChange();

            _name.text = _nameQueue.Dequeue();
            _talk.text = _talkQueue.Dequeue();
        }
        else if(slide == (int)SlideForm.Select)
        {
            _isSelection = true;
            BoxFormChange();

            _name.text = _nameQueue.Dequeue();
            _selectionText.text = _talkQueue.Dequeue();
            _selectButton1.text = _button1Queue.Dequeue();
            _selectButton2.text = _button2Queue.Dequeue();
        }
    }


    /// <summary>
    /// 대화 모드에 정보 추가 <br/>
    /// name : 대화창 이름 <br/>
    /// talk : 대화 내용 <br/>
    /// </summary>
    public void AddTalk(string name, string talk)
    {
        _nameQueue.Enqueue(name);
        _talkQueue.Enqueue(talk);
        _slide.Enqueue((int)SlideForm.Talk);
    }

    /// <summary>
    /// 선택 모드에 정보 추가 <br/>
    /// name : 대화창 이름 <br/>
    /// talk : 대화 내용 <br/>
    /// button1 : 첫 번째 버튼 텍스트 <br/>
    /// button2 : 두 번째 버튼 텍스트 <br/>
    /// </summary>
    public void AddSelection(string name, string talk, string button1, string button2)
    {
        _nameQueue.Enqueue(name);
        _talkQueue.Enqueue(talk);
        _talkQueue.Enqueue(button1);
        _talkQueue.Enqueue(button2);
        _slide.Enqueue((int)SlideForm.Talk);
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
