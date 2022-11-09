using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VPSLocationManager : MonoBehaviour
{
    [SerializeField] private GameObject[] _vpsLocation;

    // TODO : �׽�Ʈ�� ���� �ӽ� Invoke()ó�� ����. ���� ���� ���
    private void Start()
    {
        Invoke("ActiveVPSLocation", 3f);
    }
    /// <summary>
    /// �������� �ε����� ���� �ش��ϴ� VPS �̺�Ʈ ��θ� �Ѵ� �Լ�
    /// </summary>
    public void ActiveVPSLocation()
    {
        InActiveAllVPSLocation();

        _vpsLocation[GameManager.Instance.CurrentStageIndex].SetActive(true);
    }

    // VPS �����̼� ���� ��Ȱ��ȭ
    private void InActiveAllVPSLocation()
    {
        foreach(var vpsLocation in _vpsLocation)
        {
            vpsLocation.SetActive(false);
        }
    }
}
