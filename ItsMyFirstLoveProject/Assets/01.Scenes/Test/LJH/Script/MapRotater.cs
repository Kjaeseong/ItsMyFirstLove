using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapRotater : MonoBehaviour
{
    [SerializeField] GameObject _player;

    // 인스펙터 창에서 스테이지 순서대로 기준이 될 건물이름을 넣으면 됨
    [SerializeField] private string[] _defaultBuildingName;

    [SerializeField] private GameObject[] _map;

    // 해당 챕터에서 맵 맞추기위해 바라볼 건물
    [SerializeField] private GameObject[] _defaultBuilding;

    /// <summary>
    /// 등록된 건물이름과 스테이지 인덱스로 건물을 특정한 뒤 게임오브젝트에 저장, 반드시 맵이 로드된 후 실행되어야 함 (중요)
    /// </summary>
    private void SetDefaultBuilding()
    {
        // 일반 맵
        foreach(var defaultBuilding in _map[0].GetComponentsInChildren<Transform>())
        {
            if(defaultBuilding.gameObject.name == _defaultBuildingName[0])
            {
                _defaultBuilding[0] = defaultBuilding.gameObject;
                break;
            }
        }
        // 미니맵
        foreach(var miniMapDefaultBuilding in _map[1].GetComponentsInChildren<Transform>())
        {
            if(miniMapDefaultBuilding.gameObject.name == _defaultBuildingName[0])
            {
                _defaultBuilding[1] = miniMapDefaultBuilding.gameObject;
                break;
            }
        }
    }
    
    /// <summary>
    /// 저장된 게임오브젝트 건물을 이용하여 맵을 회전시키는 함수
    /// </summary>
    public void RotateMap()
    {
        SetDefaultBuilding();

        for(int i = 0; i < _defaultBuilding.Length; i++)
        {
            Vector3 dir = _defaultBuilding[i].transform.position - Camera.main.transform.position;
            dir.y = 0f;
            Quaternion _rotation = Quaternion.LookRotation(dir.normalized);
            _player.transform.rotation = _rotation;
            _map[i].transform.RotateAround(
                Camera.main.transform.position,
                Vector3.up,
                -1 * _player.transform.rotation.eulerAngles.y
            );
        }
    }
}
