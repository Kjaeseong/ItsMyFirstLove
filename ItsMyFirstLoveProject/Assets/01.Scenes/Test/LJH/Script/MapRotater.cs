using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapRotater : MonoBehaviour
{
    [SerializeField] GameObject _player;

    // �ν����� â���� �������� ������� ������ �� �ǹ��̸��� ������ ��
    [SerializeField] private string[] _defaultBuildingName;

    // �ش� é�Ϳ��� �� ���߱����� �ٶ� �ǹ�
    private GameObject _defaultBuilding;

    private Quaternion _rotation;
    
    // TODO : �ӽ� ���� ����, ���� ���ӸŴ������� �������� �ε��� ��� ���ɽ� �װɷ� ��ü�ؾ� ��
    private int _stageIndex;

    /// <summary>
    /// ��ϵ� �ǹ��̸��� �������� �ε����� �ǹ��� Ư���� �� ���ӿ�����Ʈ�� ����, �ݵ�� ���� �ε�� �� ����Ǿ�� �� (�߿�)
    /// </summary>
    public void SetDefaultBuilding()
    {
        _defaultBuilding = GameObject.Find(_defaultBuildingName[_stageIndex]);
    }
    
    /// <summary>
    /// ����� ���ӿ�����Ʈ �ǹ��� �̿��Ͽ� ���� ȸ����Ű�� �Լ�
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
