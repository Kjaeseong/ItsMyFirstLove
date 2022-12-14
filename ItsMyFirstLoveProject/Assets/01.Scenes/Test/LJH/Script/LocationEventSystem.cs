using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocationEventSystem : MonoBehaviour
{
    // TODO : 이벤트 발생 콜라이더 임시 Ver입니다. 추후 추가되는 이벤트나 결과물 합칠 때 각자 작업본에 따라서 수정 요망

    [SerializeField] private InGameUI _ui;

    [SerializeField] private CSVReader _csvReader;

    [SerializeField] private VPSEffectManager _vpsEffectManager;

    // 일회성 이벤트는 체크!
    [SerializeField] private bool _isPlayOneTime;

    [SerializeField] private bool _vpsEventOn;
    [SerializeField] private int _vpsIndex;

    [SerializeField] private bool _lineEventOn;
    //[SerializeField] private string[] _line; // 임시로 이렇게 해 놓음. 추후 _csvReader 에서 받아온 대사 넣으면 될 것 같습니다. ps. SerializeField는 줄 맞춤용으로 써놓은 것입니다.
    [SerializeField] private int _startCharID;
    [SerializeField] private int _endCharID;

    [SerializeField] private bool _audioEventOn;
    [SerializeField] private string _audioName;

    [SerializeField] private bool _favoriteEventOn;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("EventTrigger"))
        {
            Debug.Log("이벤트 실행");
            // VPS 연출
            if (_vpsEventOn)
            {
                _vpsEffectManager.ActivatedEffect(_vpsIndex, transform.position);
            }
            // 대사 연출
            if (_lineEventOn)
            {
                for (int i = 0; i < GameManager.Instance._csv.GetCSVLength("ProtoLine"); i++)
                {
                    if (int.Parse(GameManager.Instance._csv.GetCSV("ProtoLine", i, "charID")) >= _startCharID &&
                        int.Parse(GameManager.Instance._csv.GetCSV("ProtoLine", i, "charID")) <= _endCharID)
                    {
                        _ui.AddCommuTalk(GameManager.Instance._csv.GetCSV("ProtoLine", i, "Talker"), GameManager.Instance._csv.GetCSV("ProtoLine", i, "Talk"));
                    }
                }
                //_ui.AddCommuTalk("nn", "jjj");
                _ui.CommuUI();
            }
            // 사운드 출력
            if (_audioEventOn)
            {
                GameManager.Instance._audio.Play(_audioName);
            }
            // 취향 이벤트

            // 기타 추가 이벤트
            //Debug.Log($"{_audioName.Substring(0, _audioName.LastIndexOf('_'))}");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("EventTrigger"))
        {
            //Debug.Log($"{_audioName.Substring(0, _audioName.LastIndexOf('_'))}");
            if (_vpsEventOn)
            {
                _vpsEffectManager.DeactivateEffect(_vpsIndex);
            }
            if (_audioEventOn)
            {
                GameManager.Instance._audio.Stop(_audioName.Substring(0, _audioName.LastIndexOf('_')));
            }
        }

        if (_isPlayOneTime)
        {
            gameObject.SetActive(false);
        }
    }
}
