using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CharacterCommunicationUI : MonoBehaviour
{
    private enum SlideForm
    {
        TALK,
        SELECT2,
        SELECT3
    }
    [SerializeField] private GameObject _talkCanvas;
    [SerializeField] private GameObject _SelectionCanvasDouble;
    [SerializeField] private GameObject _SelectionCanvasTriple;

    [SerializeField] private TextMeshProUGUI _name;
    [SerializeField] private TextMeshProUGUI _talk;
    [SerializeField] private TextMeshProUGUI _selectionText;
    [SerializeField] private TextMeshProUGUI _selectButton1InDouble;
    [SerializeField] private TextMeshProUGUI _selectButton2InDouble;
    [SerializeField] private TextMeshProUGUI _selectButton1InTriple;
    [SerializeField] private TextMeshProUGUI _selectButton2InTriple;
    [SerializeField] private TextMeshProUGUI _selectButton3InTriple;

    private Queue<string> _nameQueue = new Queue<string>();
    private Queue<string> _talkQueue = new Queue<string>();
    private Queue<string> _button1Queue = new Queue<string>();
    private Queue<string> _button1ResultQueue = new Queue<string>();
    private Queue<string> _button2Queue = new Queue<string>();
    private Queue<string> _button2ResultQueue = new Queue<string>();
    private Queue<string> _button3Queue = new Queue<string>();
    private Queue<string> _button3ResultQueue = new Queue<string>();
    private Queue<int> _slide = new Queue<int>();

    private string _selectedNextDescript = "";

    private bool _isSelection;

    private int currentSlide;

    private void OnEnable() 
    {
        SlideInit();
    }

    /// <summary>
    /// 대화 슬라이드 배경 터치시 동작
    /// 선택 모드가 아닐때만 터치 반응
    /// </summary>
    public void BackGroundTouch()
    {
        if(!_isSelection)
        {
            SlideInit();
        }
    }

    /// <summary>
    /// 대화 슬라이드 내용 초기화 및 설정
    /// 큐에 내용이 없다면 UI비활성화
    /// </summary>
    public void SlideInit()
    {
        if(_slide.Count <= 0)
        {
            gameObject.SetActive(false);
            return;
        }
        currentSlide = _slide.Peek();
        switch (_slide.Dequeue())
        {
            case (int)SlideForm.TALK:
                _isSelection = false;
                BoxFormChange();
                _name.text = _nameQueue.Dequeue();
                _talk.text = _talkQueue.Dequeue();
                break;
            case (int)SlideForm.SELECT2:
                _isSelection = true;
                BoxFormChange();
                _name.text = _nameQueue.Dequeue();
                _selectionText.text = _talkQueue.Dequeue();
                _selectButton1InDouble.text = _button1Queue.Dequeue();
                //_button1ResultQueue.Dequeue();
                _selectButton2InDouble.text = _button2Queue.Dequeue();
                //_button2ResultQueue.Dequeue();
                break;
            case (int)SlideForm.SELECT3:
                _isSelection = true;
                BoxFormChange();
                _name.text = _nameQueue.Dequeue();
                _selectionText.text = _talkQueue.Dequeue();
                _selectButton1InTriple.text = _button1Queue.Dequeue();
                //_button1ResultQueue.Dequeue();
                _selectButton2InTriple.text = _button2Queue.Dequeue();
                //_button2ResultQueue.Dequeue();
                _selectButton3InTriple.text = _button3Queue.Dequeue();
                //_button3ResultQueue.Dequeue();
                break;
        }

        if(_selectedNextDescript != "")
        {
            _talk.text = _selectedNextDescript;
            _selectionText.text= _selectedNextDescript;
            _selectedNextDescript = "";
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
        _slide.Enqueue((int)SlideForm.TALK);
    }

    /// <summary>
    /// 선택 모드에 정보 추가 <br/>
    /// name : 대화창 이름 <br/>
    /// talk : 대화 내용 <br/>
    /// button1 : 첫 번째 버튼의 텍스트 <br/>
    /// button1result : 첫 번째 버튼에 따른 대사 <br/>
    /// button2 : 두 번째 버튼의 텍스트 <br/>
    /// /// button2result : 두 번째 버튼에 따른 대사 <br/>
    /// </summary>
    public void AddSelection(string name, string talk, string button1, string button1result, string button2, string button2result)
    {
        _nameQueue.Enqueue(name);
        _talkQueue.Enqueue(talk);
        _button1Queue.Enqueue(button1);
        _button1ResultQueue.Enqueue(button1result);
        _button2Queue.Enqueue(button2);
        _button2ResultQueue.Enqueue(button2result);
        _slide.Enqueue((int)SlideForm.SELECT2);
    }

    /// <summary>
    /// 선택 모드에 정보 추가 <br/>
    /// name : 대화창 이름 <br/>
    /// talk : 대화 내용 <br/>
    /// button1 : 첫 번째 버튼의 텍스트 <br/>
    /// button1result : 첫 번째 버튼에 따른 대사 <br/>
    /// button2 : 두 번째 버튼의 텍스트 <br/>
    /// button2result : 두 번째 버튼에 따른 대사 <br/>
    /// button2 : 세 번째 버튼의 텍스트 <br/>
    /// button2result : 세 번째 버튼에 따른 대사 <br/>
    /// </summary>
    public void AddSelection(string name, string talk, string button1, string button1result, string button2, string button2result, string button3, string button3result)
    {
        _nameQueue.Enqueue(name);
        _talkQueue.Enqueue(talk);
        _button1Queue.Enqueue(button1);
        _button1ResultQueue.Enqueue(button1result);
        _button2Queue.Enqueue(button2);
        _button2ResultQueue.Enqueue(button2result);
        _button3Queue.Enqueue(button3);
        _button3ResultQueue.Enqueue(button3result);
        _slide.Enqueue((int)SlideForm.SELECT3);
    }

    /// <summary>
    /// 버튼 선택시 버튼에 따라 다른 이벤트 실행을 위한 함수 <br/>
    /// 버튼 이벤트에 1 혹은 2 혹은 3부여 <br/>
    /// </summary>
    public void SelectButton(int select)
    {
        switch(select)
        {
            case 1:
                // 버튼 1 선택시 이벤트
                _selectedNextDescript = _button1ResultQueue.Dequeue();
                break;
            case 2:
                // 버튼 2 선택시 이벤트
                _selectedNextDescript = _button2ResultQueue.Dequeue();
                break;
            case 3:
                // 버튼 3 선택시 이벤트
                _selectedNextDescript = _button3ResultQueue.Dequeue();
                break;
            default:
                break;
        }
    }

    private void BoxFormChange()
    {
        if(currentSlide == 0)
        {
            _talkCanvas.SetActive(true);
            _SelectionCanvasDouble.SetActive(false);
            _SelectionCanvasTriple.SetActive(false);
        }
        else if(currentSlide == 1)
        {
            _talkCanvas.SetActive(false);
            _SelectionCanvasDouble.SetActive(true);
            _SelectionCanvasTriple.SetActive(false);
        }
        else
        {
            _talkCanvas.SetActive(true);
            _SelectionCanvasDouble.SetActive(false);
            _SelectionCanvasTriple.SetActive(true);
        }
    }

}
