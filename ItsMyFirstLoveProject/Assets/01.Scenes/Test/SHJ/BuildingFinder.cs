using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BuildingFinder : MonoBehaviour
{
    [SerializeField] private GameObject[] _protoTypeLocation;
    [SerializeField] private GameObject[] BusinessNameObject;
    [SerializeField] private LocationFinder _character;

    public Vector3 TestPos;
    public string LocationName;
    public string[] BusinessName;
    public float[] LocationPosX;
    

    private void Start()
    {

    }

    /// <summary>
    /// 빌딩의 이름을 찾고, 그 위치에 오브젝트를 배치하는 스크립트
    /// </summary>
    public void FindBuilding()
    {
        if (SceneManager.GetActiveScene().name == "Proto_WalkScene 1")
        {
            return;
        }

        GameObject BuildingForLocation = GameObject.Find(LocationName);
        Vector3 LocationPos = BuildingForLocation.transform.position;

        // 프로토타입 경로
        _character._destinations[0] = Instantiate(_protoTypeLocation[0], new Vector3(LocationPos.x - 5.5f, 0.5f, LocationPos.z - 14), Quaternion.Euler(0, 0, 0));
        _character._destinations[1] = Instantiate(_protoTypeLocation[1], new Vector3(LocationPos.x + 18.3f, 0.5f, LocationPos.z - 23.7f), Quaternion.Euler(0, 0, 0));
        _character._destinations[2] = Instantiate(_protoTypeLocation[2], new Vector3(LocationPos.x + 43, 0.5f, LocationPos.z + 86), Quaternion.Euler(0, 0, 0));
        _character._destinations[3] = Instantiate(_protoTypeLocation[3], new Vector3(LocationPos.x + 50, 0.5f, LocationPos.z + 106), Quaternion.Euler(0, 0, 0));

        //for(int i = 0; i < _character._destinations.Length; i++)
        //{
        //    _character._destinations[i] = Instantiate(_protoTypeLocation[i], new Vector3(LocationPos.x, 0.5f, LocationPos.z), Quaternion.Euler(0, 0, 0));
        //}

        TestPos = _character._destinations[0].transform.position;
    }

    /// <summary>
    /// 빌딩의 이름을 찾고, 그 위치에 상호명을 넣는 스크립트
    /// </summary>
    public void FindBusinessName()
    {
        if(SceneManager.GetActiveScene().name == "Proto_WalkScene 1")
        {
            return;
        }

        GameObject[] BusinessNames = new GameObject[BusinessName.Length];
        Vector3[] BusinessLocation = new Vector3[BusinessName.Length];

        for (int i = 0; i < BusinessName.Length; ++i)
        {
            BusinessNames[i] = GameObject.Find(BusinessName[i]);
            BusinessLocation[i] = BusinessNames[i].transform.position;

            if (i < 4)
            {
                BusinessNameObject[0].transform.position = new Vector3(BusinessLocation[0].x + 23, BusinessLocation[0].y, BusinessLocation[0].z - 5);
                BusinessNameObject[1].transform.position = new Vector3(BusinessLocation[1].x + 11.8f, BusinessLocation[1].y, BusinessLocation[1].z - 5);
                BusinessNameObject[2].transform.position = new Vector3(BusinessLocation[2].x + 5.7f, BusinessLocation[2].y, BusinessLocation[2].z - 3.4f);
                BusinessNameObject[3].transform.position = new Vector3(BusinessLocation[3].x + 7, BusinessLocation[3].y, BusinessLocation[3].z - 3.8f);
            }

            else
            {
                BusinessNameObject[i].transform.position = BusinessLocation[i];
            }

        }
    }


}
