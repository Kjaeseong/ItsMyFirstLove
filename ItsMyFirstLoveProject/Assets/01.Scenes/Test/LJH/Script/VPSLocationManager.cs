using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VPSLocationManager : MonoBehaviour
{
    [SerializeField] private GameObject[] _vpsLocation;

    // 테스트용 임시 Invoke() 사용, 추후 스테이지 선택 후 ActiveVPSLocation() 실행 해야 함.
    private void Start()
    {
        Invoke("ActiveVPSLocation", 3f);
    }

    /// <summary>
    /// 스테이지 인덱스를 통해 해당하는 VPS 이벤트 경로를 켜는 함수
    /// </summary>
    /// <param name="vpsLocationIndex">스테이지 인덱스</param>
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
