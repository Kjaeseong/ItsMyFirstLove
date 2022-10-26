using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocationEventSystem : MonoBehaviour
{
    // TODO : �̺�Ʈ �߻� �ݶ��̴� �ӽ� Ver�Դϴ�. ���� �߰��Ǵ� �̺�Ʈ�� ����� ��ĥ �� ���� �۾����� ���� ���� ���

    [SerializeField] private CSVReader _csvReader;

    [SerializeField] private VPSEffectManager _vpsEffectManager;

    // ��ȸ�� �̺�Ʈ�� üũ!
    [SerializeField] private bool _isPlayOneTime;

    [SerializeField] private bool _vpsEventOn;
    [SerializeField] private int _vpsIndex;

    [SerializeField] private bool _lineEventOn;
    [SerializeField] private string _line; // �ӽ÷� �̷��� �� ����. ���� _csvReader ���� �޾ƿ� ��� ������ �� �� �����ϴ�. ps. SerializeField�� �� ��������� ����� ���Դϴ�.

    [SerializeField] private bool _favoriteEventOn;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("EventTrigger"))
        {
            Debug.Log("�̺�Ʈ ����");
            // VPS ����
            _vpsEffectManager.ActivatedEffect(0,transform.position);
            // ��� ����

            // ���� ���

            // ���� �̺�Ʈ

            // ��Ÿ �߰� �̺�Ʈ

            if (_isPlayOneTime)
            {
                gameObject.SetActive(false);
            }
        }
    }
}
