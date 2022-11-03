using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocationEventSystem : MonoBehaviour
{
    // TODO : �̺�Ʈ �߻� �ݶ��̴� �ӽ� Ver�Դϴ�. ���� �߰��Ǵ� �̺�Ʈ�� ����� ��ĥ �� ���� �۾����� ���� ���� ���

    [SerializeField] private InGameUI _ui;
    [SerializeField] private CSVReader _csvReader;
    [SerializeField] private VPSEffectManager _vpsEffectManager;

    // ��ȸ�� �̺�Ʈ�� üũ!
    [SerializeField] private bool _isPlayOneTime;

    // VPS
    [SerializeField] private bool _vpsEventOn;
    [SerializeField] private int _vpsIndex;

    // ���
    [SerializeField] private bool _lineEventOn;
    [SerializeField] private int _startCharID;
    [SerializeField] private int _endCharID;

    // ����
    [SerializeField] private bool _audioEventOn;
    [SerializeField] private string _audioName;

    // ����
    [SerializeField] private bool _favoriteEventOn;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("EventTrigger"))
        {
            Debug.Log("�̺�Ʈ ����");
            // VPS ����
            if (_vpsEventOn)
            {
                _vpsEffectManager.ActivatedEffect(_vpsIndex, transform.position);
            }
            // ��� ����
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
            // ���� ���
            if (_audioEventOn)
            {
                GameManager.Instance._audio.Play(_audioName);
            }

            // ���� �̺�Ʈ
            if(_favoriteEventOn)
            {

            }

            // ��Ÿ �߰� �̺�Ʈ
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("EventTrigger"))
        {
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
