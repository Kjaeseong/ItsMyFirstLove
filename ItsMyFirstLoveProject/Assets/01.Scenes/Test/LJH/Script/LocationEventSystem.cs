using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class LocationEventSystem : MonoBehaviour
{
    // TODO : �̺�Ʈ �߻� �ݶ��̴� �ӽ� Ver�Դϴ�. ���� �߰��Ǵ� �̺�Ʈ�� ����� ��ĥ �� ���� �۾����� ���� ���� ���

    [SerializeField] private InGameUI _ui;
    [SerializeField] private CSVReader _csvReader;
    [SerializeField] private VPSEffectManager _vpsEffectManager;
    private AnimationSupport _animationSupport;

    // ��ȸ�� �̺�Ʈ�� üũ!
    [SerializeField] private bool _isPlayOneTime;

    // VPS
    [SerializeField] private bool _vpsEventOn;
    [SerializeField] private int _vpsIndex;

    //// ���
    //[SerializeField] private bool _lineEventOn;
    //[SerializeField] private int _startCharID;
    //[SerializeField] private int _endCharID;

    // ���
    [SerializeField] private bool _lineEventOn;

    [Serializable]
    private class LineSystem
    {
        [Header("Description")] 
        public string Talker;
        public string Description;
        [Header("Select")]
        public string Select1;
        public string Select1Description;
        public string Select2;
        public string Select2Description;
        public string Select3;
        public string Select3Description;
        [Header("Animation")]
        public string AnimationName;
    }

    [SerializeField] private LineSystem[] _lineSystems;

    // ����
    [SerializeField] private bool _audioEventOn;
    [SerializeField] private string _audioName;

    // ����
    [SerializeField] private bool _favoriteEventOn;

    private bool _isActivedEvent;
    private float _eventOffDistance = 11f;

    private void OnEnable()
    {
        InitLine();
    }

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
            Debug.Log("�̺�Ʈ ����");
            // VPS ����
            VPSEvent();
            // ��� ����
            LineEvent();
            // ���� ���
            AudioEvent();
            // ���� �̺�Ʈ �ۼ�
            FavoriteEvent();
            // ��Ÿ �߰� �̺�Ʈ �߰��� �Ʒ� ��ġ�� �߰� �ۼ� ���
        }
    }

    private void VPSEvent()
    {
        if (_vpsEventOn)
        {
            _vpsEffectManager.ActivatedEffect(_vpsIndex, transform.position);
        }
    }

    private void InitLine()
    {
        foreach (var line in _lineSystems)
        {
            //string[] splitLine  = line.Split('/');
            if (line.Select3 != "" && line.Select1 != "")
            {
                _ui.AddCommuSelect(line.Talker, line.Description, line.Select1, line.Select1Description, line.Select2, line.Select2Description, line.Select3, line.Select3Description);
            }
            else if (line.Select2 != "")
            {
                _ui.AddCommuSelect(line.Talker, line.Description, line.Select1, line.Select1Description, line.Select2, line.Select2Description);
            }
            else
            {
                _ui.AddCommuTalk(line.Talker, line.Description);
            }

            if (line.AnimationName != "")
            {
                _animationSupport.PlayAnimationTrigger(line.AnimationName);
            }
        }
    }
    private void LineEvent()
    {
        if (_lineEventOn)
        {
            // ���� ver
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
