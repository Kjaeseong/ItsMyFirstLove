using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitLocationEvents : MonoBehaviour
{
    // 초기 위치의 절대위치가 될 건물 이름
    [SerializeField] private string _buildingName;

    [SerializeField] private GameObject _buildings;

    // 경로의 시작 위치 설정할 때 기반으로 할 건물과의 포지션 차이
    private Vector3 _setLocationVector = new Vector3(-6f, 0f, 10.3f);

    // TODO : 지금 임시로 Invoke로 처리하는 부분이 좀 있는데 추후 순서에 따라 진행 될 수 있게 작업 요망 ex) 맵 로드 완료 후 실행
    private void Start()
    {
        Invoke("SetLocation", 3f);
    }

    
    // 공원 앞 건물 기반 이벤트 발생 경로 설정
    private void SetLocation()
    {
        foreach(var go in _buildings.GetComponentsInChildren<Transform>())
        {
            if(go.name == _buildingName)
            {
                transform.position = go.transform.position + _setLocationVector;

                break;
            }
        }
    }
}
