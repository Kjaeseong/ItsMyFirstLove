using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VPSLocationManager : MonoBehaviour
{
    [SerializeField] private GameObject[] _vpsLocation;

    // �׽�Ʈ�� �ӽ� Invoke() ���, ���� �������� ���� �� ActiveVPSLocation() ���� �ؾ� ��.
    private void Start()
    {
        Invoke("ActiveVPSLocation", 3f);
    }

    // TODO : ���� �������� �� �ε� ���� �ٸ� ������ ���������� �� ��� �ش� ��ũ��Ʈ ������ ���ӸŴ����� �ű�� ���� ��õ
    /// <summary>
    /// �������� �ε����� ���� �ش��ϴ� VPS �̺�Ʈ ��θ� �Ѵ� �Լ�
    /// </summary>
    /// <param name="vpsLocationIndex">�������� �ε���</param>
    public void ActiveVPSLocation()
    {
        ClearVPSLocation();

        _vpsLocation[GameManager.Instance.StageIndex].SetActive(true);
    }

    private void ClearVPSLocation()
    {
        foreach(var vpsLocation in _vpsLocation)
        {
            vpsLocation.SetActive(false);
        }
    }
}
