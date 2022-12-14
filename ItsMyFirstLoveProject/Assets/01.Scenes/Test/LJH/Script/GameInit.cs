using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Google.Maps.Examples;

public class GameInit : MonoBehaviour
{

    [SerializeField] private Transform _map;
    [SerializeField] private Transform _arCameraTransform;
    [SerializeField] private PositionSensor _pos;
    [SerializeField] private BasicExample _mapLoader;


    private float _tryInitTime = 0.1f;

    private void Start()
    {
        StartCoroutine(InitGame());
    }

    // 바닥 인식 후 코루틴 실행 요망, 코루틴 종료되면 UI로 건물위치 미세 수정 필요
    IEnumerator InitGame()
    {
        while (true)
        {
            // GPS 값 받아온 후
            //if(_pos.GetIsGpsStart())
            //{
            if(_pos.GetLat() != 0 && _pos.GetLong() != 0)
            {
                _mapLoader.LoadMap(_pos.GetLat(), _pos.GetLong());

                // 맵 회전
                InitMapRotate();

                break;
            }
            // 맵 로드
            
            //}
            yield return new WaitForSeconds(_tryInitTime);
        }
        StopCoroutine(InitGame());
    }

    /// <summary>
    /// Extensions상의 북쪽과 현재 AR 카메라의 각도 차를 이용하여 맵을 회전시키는 함수
    /// </summary>
    public void InitMapRotate()
    {
        double angle = _pos.GetAzimuth();
        while (false == (_map.rotation.eulerAngles.y > (360 - angle - 2) % 360 && _map.rotation.eulerAngles.y < (360 - angle + 2) % 360))
        {
            _map.transform.RotateAround(_arCameraTransform.position, Vector3.up, 10f * Time.deltaTime);
        }
    }
}
