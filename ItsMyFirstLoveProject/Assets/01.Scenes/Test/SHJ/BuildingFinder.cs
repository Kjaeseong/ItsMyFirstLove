using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BuildingFinder : MonoBehaviour
{
    [SerializeField] private LocationFinder _character;
    [SerializeField] private GameObject[] _ProtoTypeLocations;
    [SerializeField] private GameObject _ProtoTypeBusinessName;

    public string LocationNameOfBenchMark;
    private float StageNumber;

    private void Start()
    {
        // TODO : �ӽ÷� �ǹ� ���� ó�� �� ��, ���� �ǹ� ȸ���� �Է����� �� �������� �ؾ� ��.
        Invoke("FindBuilding", 1f);
        Invoke("FindBusinessName", 1f);
    }

    /// ������ �̸��� ã��, �� ��ġ�� ������Ʈ�� ��ġ�ϴ� ��ũ��Ʈ
    private void FindBuilding()
    {
        _ProtoTypeLocations[GameManager.Instance.CurrentStageIndex].SetActive(true);

        GameObject BuildingForLocation = GameObject.Find(LocationNameOfBenchMark);
        Vector3 LocationPos = BuildingForLocation.transform.position;
        _ProtoTypeLocations[GameManager.Instance.CurrentStageIndex].transform.position = LocationPos;

        for (int i = 0; i < _character._destinations.Length; i++)
        {
            _character._destinations[i] = _ProtoTypeLocations[GameManager.Instance.CurrentStageIndex].transform.GetChild(i).gameObject;
        }
    }

    /// ������ �̸��� ã��, �� ��ġ�� ��ȣ���� �ִ� ��ũ��Ʈ
    private void FindBusinessName()
    {
        GameObject BuildingForLocation = GameObject.Find(LocationNameOfBenchMark);
        Vector3 LocationPos = BuildingForLocation.transform.position;
        _ProtoTypeBusinessName.transform.position = LocationPos;
    }


}
