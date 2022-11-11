using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    
    // ����
    [SerializeField] private bool _audioEventOn;
    [SerializeField] private string _audioName;

    // ����
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
            Debug.Log("�̺�Ʈ ����");
            // VPS ����
            if (_vpsEventOn)
            {
                _vpsEffectManager.ActivatedEffect(_vpsIndex, transform.position);
            }
            // ��� ����
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
            // ���� ���
            if (_audioEventOn)
            {
                GameManager.Instance._audio.Play(_audioName);
            }

            // ���� �̺�Ʈ �ۼ�
            if(_favoriteEventOn)
            {

            }

            // ��Ÿ �߰� �̺�Ʈ �߰��� �Ʒ� ��ġ�� �߰� �ۼ� ���
        }
    }

}
