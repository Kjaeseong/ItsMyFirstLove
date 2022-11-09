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
        Invoke("FindBuilding", 1f);
        Invoke("FindBusinessName", 1f);
    }

    /// 빌딩의 이름을 찾고, 그 위치에 오브젝트를 배치하는 스크립트
    private void FindBuilding()
    {
        if (SceneManager.GetActiveScene().name == "Proto_WalkScene 1")
        {
            return;
        }

        GameObject BuildingForLocation = GameObject.Find(LocationNameOfBenchMark);
        Vector3 LocationPos = BuildingForLocation.transform.position;
        _ProtoTypeLocations[GameManager.Instance.CurrentStageIndex].transform.position = LocationPos;

        for (int i = 0; i < _character._destinations.Length; i++)
        {
            _character._destinations[i] = _ProtoTypeLocations[GameManager.Instance.CurrentStageIndex].transform.GetChild(i).gameObject;
        }
    }

    /// 빌딩의 이름을 찾고, 그 위치에 상호명을 넣는 스크립트
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
