using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

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

    [Serializable]
    public class LineSystem
    {
        [Header("Description")] 
        public string Talker;
        public string Description;
        [Header("Select")]
        public string[] Selects;
        [Header("Animation")]
        public string AnimationName;
        [Header("VPSEffect")]
        public int VPSIndex;
    }

    public enum Select
    {
        FIRST,
        FIRSTDESC,
        SECOND,
        SECONDDESC,
        THIRD,
        THIRDDESC
    }

    [SerializeField] private LineSystem[] _lineSystems;

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
        //_animationSupport = other.GetComponentInChildren<AnimationSupport>();
        if (other.CompareTag("EventTrigger"))
        {
            _isActivedEvent = true;
            _ui.SetCurrentLocationInGameUI(gameObject.GetComponent<LocationEventSystem>());
            Debug.Log("이벤트 실행");
            // 대사 초기화
            InitLine();
            // VPS 연출
            //VPSEvent();
            // 대사 연출
            LineEvent();
            // 사운드 출력
            AudioEvent();
            // 취향 이벤트 작성
            FavoriteEvent();
            // 기타 추가 이벤트 추가시 아래 위치에 추가 작성 요망
        }
    }

    /// <summary>
    /// VPS 이펙트 실행
    /// </summary>
    /// <param name="vpsIndex"></param>
    public void VPSEventOnWithDesc(int vpsIndex)
    {
        _vpsEffectManager.ActivatedEffect(vpsIndex, transform.position);
    }

    private void InitLine()
    {
        foreach (var line in _lineSystems)
        {
            if (line.Selects.Length == 6)//line.Selects[(int)Select.THIRD] != null)
            {
                _ui.AddCommuSelect(line.Talker, line.Description,
                    line.Selects[(int)Select.FIRST],
                    line.Selects[(int)Select.FIRSTDESC],
                    line.Selects[(int)Select.SECOND],
                    line.Selects[(int)Select.SECONDDESC],
                    line.Selects[(int)Select.THIRD],
                    line.Selects[(int)Select.THIRDDESC]);
            }
            else if (line.Selects.Length == 4)//line.Selects[(int)Select.SECOND] != null)
            {
                _ui.AddCommuSelect(line.Talker, line.Description,
                    line.Selects[(int)Select.FIRST],
                    line.Selects[(int)Select.FIRSTDESC],
                    line.Selects[(int)Select.SECOND],
                    line.Selects[(int)Select.SECONDDESC]);
            }
            else
            {
                _ui.AddCommuTalk(line.Talker, line.Description);
            }

            _ui.AddAnimationWithTalk(line.AnimationName);

            _ui.AddVPSEffectWithTalk(line.VPSIndex - 1);
        }
    }
    private void LineEvent()
    {
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
            _ui.CommuUI();
        }
    }

    private void AudioEvent()
    {
        if (_audioEventOn)
        {
            GameManager.Instance._audio.Play(_audioName);
        }
    }

    private void FavoriteEvent()
    {
        if (_favoriteEventOn)
        {

        }
    }
}
