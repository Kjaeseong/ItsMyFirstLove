using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocationEventSystem : MonoBehaviour
{
    // TODO : 이벤트 발생 콜라이더 임시 Ver입니다. 추후 추가되는 이벤트나 결과물 합칠 때 각자 작업본에 따라서 수정 요망

    [SerializeField] private InGameUI _ui;
    [SerializeField] private CSVReader _csvReader;
    [SerializeField] private VPSEffectManager _vpsEffectManager;
    private AnimationSupport _animationSupport;

    // 일회성 이벤트는 체크!
    [SerializeField] private bool _isPlayOneTime;

    // VPS
    [SerializeField] private bool _vpsEventOn;
    [SerializeField] private int _vpsIndex;

    //// 대사
    //[SerializeField] private bool _lineEventOn;
    //[SerializeField] private int _startCharID;
    //[SerializeField] private int _endCharID;

    // 대사
    [SerializeField] private bool _lineEventOn;
    [SerializeField] private string[] _lineSystemString;
    private string[] _splitLine; 

    private enum Line
    {
        TALKER,
        LINE,
        LEFTSELECT,
        RIGHTSELECT,
        ANIMATION
    }
    
    // 사운드
    [SerializeField] private bool _audioEventOn;
    [SerializeField] private string _audioName;

    // 취향
    [SerializeField] private bool _favoriteEventOn;

    private bool _isActivedEvent;
    private float _eventOffDistance = 11f;

    private void Update()
    {
        if (!_isActivedEvent) 
        {
            return;
        }

        if (Vector3.Distance(Camera.main.transform.position, transform.position) > _eventOffDistance)
        {
            if (_vpsEventOn)
            {
                _vpsEffectManager.DeactivateEffect(_vpsIndex);
            }
            if (_audioEventOn)
            {
                GameManager.Instance._audio.Stop(_audioName.Substring(0, _audioName.LastIndexOf('_')));
            }
            if (_isPlayOneTime)
            {
                gameObject.SetActive(false);
            }
            _isActivedEvent = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        _animationSupport = other.GetComponentInChildren<AnimationSupport>();
        if (other.CompareTag("EventTrigger"))
        {
            _isActivedEvent = true;
            Debug.Log("이벤트 실행");
            // VPS 연출
            if (_vpsEventOn)
            {
                _vpsEffectManager.ActivatedEffect(_vpsIndex, transform.position);
            }
            // 대사 연출
            if (_lineEventOn)
            {
                // 기존 ver
                //for (int i = 0; i < GameManager.Instance._csv.GetCSVLength("ProtoLine"); i++)
                //{
                //    if (int.Parse(GameManager.Instance._csv.GetCSV("ProtoLine", i, "charID")) >= _startCharID &&
                //        int.Parse(GameManager.Instance._csv.GetCSV("ProtoLine", i, "charID")) <= _endCharID)
                //    {
                //        _ui.AddCommuTalk(GameManager.Instance._csv.GetCSV("ProtoLine", i, "Talker"), GameManager.Instance._csv.GetCSV("ProtoLine", i, "Talk"));
                //    }
                //}
                //_ui.CommuUI();

                foreach(var line in _lineSystemString)
                {
                    _splitLine = line.Split('/');
                    if (_splitLine[(int)Line.LEFTSELECT] != " ")
                    {
                        _ui.AddCommuSelect(_splitLine[(int)Line.TALKER],
                                           _splitLine[(int)Line.LINE],
                                           _splitLine[(int)Line.LEFTSELECT],
                                           _splitLine[(int)Line.RIGHTSELECT]);
                    }
                    else
                    {
                        _ui.AddCommuTalk(_splitLine[(int)Line.TALKER], _splitLine[(int)Line.LINE]);
                    }

                    if (_splitLine[(int)Line.ANIMATION] != "\n")
                    {
                        _animationSupport.PlayAnimationTrigger(_splitLine[(int)Line.ANIMATION]);
                    }
                }
            }
            // 사운드 출력
            if (_audioEventOn)
            {
                GameManager.Instance._audio.Play(_audioName);
            }

            // 취향 이벤트 작성
            if(_favoriteEventOn)
            {

            }

            // 기타 추가 이벤트 추가시 아래 위치에 추가 작성 요망
        }
    }

}
