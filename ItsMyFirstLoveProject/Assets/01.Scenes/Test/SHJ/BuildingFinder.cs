using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BuildingFinder : MonoBehaviour
{
    [SerializeField] private LocationFinder _character;
    [SerializeField] private GameObject _ProtoTypeLocations;
    [SerializeField] private GameObject _ProtoTypeBusinessName;

    public string LocationNameOfBenchMark;

    private void Start()
    {
        Invoke("FindBuilding", 1f);
        Invoke("FindBusinessName", 1f);
    }

    /// ������ �̸��� ã��, �� ��ġ�� ������Ʈ�� ��ġ�ϴ� ��ũ��Ʈ
    private void FindBuilding()
    {
        if (SceneManager.GetActiveScene().name == "Proto_WalkScene 1")
        {
            return;
        }

        GameObject BuildingForLocation = GameObject.Find(LocationNameOfBenchMark);
        Vector3 LocationPos = BuildingForLocation.transform.position;
        _ProtoTypeLocations.transform.position = LocationPos;

        for (int i = 0; i < _character._destinations.Length; i++)
        {
            _character._destinations[i] = _ProtoTypeLocations.transform.GetChild(i).gameObject;
        }
    }

    /// ������ �̸��� ã��, �� ��ġ�� ��ȣ���� �ִ� ��ũ��Ʈ
    private void FindBusinessName()
    {
        if (SceneManager.GetActiveScene().name == "Proto_WalkScene 1")
        {
            return;
        }

        GameObject BuildingForLocation = GameObject.Find(LocationNameOfBenchMark);
        Vector3 LocationPos = BuildingForLocation.transform.position;
        _ProtoTypeBusinessName.transform.position = LocationPos;
    }


}
