using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapRotater : MonoBehaviour
{
    [SerializeField] GameObject _player;

    // �ν����� â���� �������� ������� ������ �� �ǹ��̸��� ������ ��
    [SerializeField] private string[] _defaultBuildingName;

    [SerializeField] private GameObject[] _map;

    // �ش� é�Ϳ��� �� ���߱����� �ٶ� �ǹ�
    [SerializeField] private GameObject[] _defaultBuilding;

    /// <summary>
    /// ��ϵ� �ǹ��̸��� �������� �ε����� �ǹ��� Ư���� �� ���ӿ�����Ʈ�� ����, �ݵ�� ���� �ε�� �� ����Ǿ�� �� (�߿�)
    /// </summary>
    private void SetDefaultBuilding()
    {
        // �Ϲ� ��
        foreach(var defaultBuilding in _map[0].GetComponentsInChildren<Transform>())
        {
            if(defaultBuilding.gameObject.name == _defaultBuildingName[0])
            {
                _defaultBuilding[0] = defaultBuilding.gameObject;
                break;
            }
        }
        // �̴ϸ�
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
    /// ����� ���ӿ�����Ʈ �ǹ��� �̿��Ͽ� ���� ȸ����Ű�� �Լ�
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
