using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VPSLocationManager : MonoBehaviour
{
    [SerializeField] private GameObject[] _vpsLocation;

    // TODO : 테스트를 위한 임시 Invoke()처리 했음. 추후 수정 요망
    private void Start()
    {
        Invoke("ActiveVPSLocation", 3f);
    }
    /// <summary>
    /// 스테이지 인덱스를 통해 해당하는 VPS 이벤트 경로를 켜는 함수
    /// </summary>
    public void ActiveVPSLocation()
    {
        InActiveAllVPSLocation();

        _vpsLocation[GameManager.Instance.CurrentStageIndex].SetActive(true);
    }

    // VPS 로케이션 전부 비활성화
    private void InActiveAllVPSLocation()
    {
        foreach(var vpsLocation in _vpsLocation)
        {
            vpsLocation.SetActive(false);
        }
    }
}
