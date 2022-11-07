using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitLocationEvents : MonoBehaviour
{
    // �ʱ� ��ġ�� ������ġ�� �� �ǹ� �̸�
    [SerializeField] private string _buildingName;

    [SerializeField] private GameObject _map;

    // ����� ���� ��ġ ������ �� ������� �� �ǹ����� ������ ����
    [SerializeField] private Vector3 _setLocationVector;// = new Vector3(-6f, 0f, 10.3f);


    // TODO : ��ΰ� Ȱ��ȭ �� �� ���� ��. ���� �ε���� ���� ���¸� ���� �߻���. ���� �� �ε����� ��θ� ������ �Ѵٸ�, OnEnable�� �ƴ� �ٸ� ������� ó���ؾ� ��. (Ex. �Լ��� ��ȯ �� �� �ε��� ����)
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
