using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VPSLocationManager : MonoBehaviour
{
    [SerializeField] private GameObject[] _vpsLocation;

    /// <summary>
    /// �������� �ε����� ���� �ش��ϴ� VPS �̺�Ʈ ��θ� �Ѵ� �Լ�
    /// </summary>
    /// <param name="vpsLocationIndex">�������� �ε���</param>
    public void ActiveVPSLocation(int vpsLocationIndex)
    {
        ClearVPSLocation();

        _vpsLocation[vpsLocationIndex].SetActive(true);
    }

    private void ClearVPSLocation()
    {
        foreach(var vpsLocation in _vpsLocation)
        {
            vpsLocation.SetActive(false);
        }
    }
}
