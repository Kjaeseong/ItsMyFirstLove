using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapRotater : MonoBehaviour
{
    [SerializeField] GameObject _player;

    // 인스펙터 창에서 스테이지 순서대로 기준이 될 건물이름을 넣으면 됨
    [SerializeField] private string[] _defaultBuildingName;

    // 해당 챕터에서 맵 맞추기위해 바라볼 건물
    private GameObject _defaultBuilding;

    private Quaternion _rotation;
    
    // TODO : 임시 생성 변수, 추후 게임매니저에서 스테이지 인덱스 사용 가능시 그걸로 대체해야 함
    private int _stageIndex;

    /// <summary>
    /// 등록된 건물이름과 스테이지 인덱스로 건물을 특정한 뒤 게임오브젝트에 저장, 반드시 맵이 로드된 후 실행되어야 함 (중요)
    /// </summary>
    public void SetDefaultBuilding()
    {
        _defaultBuilding = GameObject.Find(_defaultBuildingName[_stageIndex]);
    }
    
    /// <summary>
    /// 저장된 게임오브젝트 건물을 이용하여 맵을 회전시키는 함수
    /// </summary>
    public void RotateMap()
    {
        Vector3 dir = _defaultBuilding.transform.position - Camera.main.transform.position;
        dir.y = 0f;
        _rotation = Quaternion.LookRotation(dir.normalized);
        _player.transform.rotation = _rotation;
        transform.RotateAround(
            Camera.main.transform.position,
            Vector3.up,
            -1 * _player.transform.rotation.eulerAngles.y
        );
    }

}
