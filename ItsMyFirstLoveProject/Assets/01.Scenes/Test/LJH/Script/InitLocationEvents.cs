using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitLocationEvents : MonoBehaviour
{
    // �ʱ� ��ġ�� ������ġ�� �� �ǹ� �̸�
    [SerializeField] private string _buildingName;

    [SerializeField] private GameObject _buildings;

    // ����� ���� ��ġ ������ �� ������� �� �ǹ����� ������ ����
    private Vector3 _setLocationVector = new Vector3(-6f, 0f, 10.3f);

    // TODO : ���� �ӽ÷� Invoke�� ó���ϴ� �κ��� �� �ִµ� ���� ������ ���� ���� �� �� �ְ� �۾� ��� ex) �� �ε� �Ϸ� �� ����
    private void Start()
    {
        Invoke("SetLocation", 3f);
    }

    
    // ���� �� �ǹ� ��� �̺�Ʈ �߻� ��� ����
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
