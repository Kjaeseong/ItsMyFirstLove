using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VPSLocationManager : MonoBehaviour
{
    [SerializeField] private GameObject[] _vpsLocation;

    /// <summary>
    /// 스테이지 인덱스를 통해 해당하는 VPS 이벤트 경로를 켜는 함수
    /// </summary>
    /// <param name="vpsLocationIndex">스테이지 인덱스</param>
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
