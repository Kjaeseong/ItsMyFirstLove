using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitLocationEvents : MonoBehaviour
{
    // 초기 위치의 절대위치가 될 건물 이름
    [SerializeField] private string _buildingName;

    [SerializeField] private GameObject _map;

    // 경로의 시작 위치 설정할 때 기반으로 할 건물과의 포지션 차이
    [SerializeField] private Vector3 _setLocationVector;// = new Vector3(-6f, 0f, 10.3f);


    // TODO : 경로가 활성화 될 때 실행 됨. 맵이 로드되지 않은 상태면 버그 발생함. 만약 맵 로드전에 경로를 정해햐 한다면, OnEnable이 아닌 다른 방법으로 처리해야 함. (Ex. 함수로 전환 후 맵 로드후 실행)
    private void OnEnable()
    {
        foreach (var go in _map.GetComponentsInChildren<Transform>())
        {
            if (go.name == _buildingName)
            {
                transform.position = go.transform.position + _setLocationVector;

                break;
            }
        }
    }
}
