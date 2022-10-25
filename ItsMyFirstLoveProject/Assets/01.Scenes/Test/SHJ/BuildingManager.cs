using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Google.Maps.Coord;
using Google.Maps.Event;
using Google.Maps.Examples.Shared;

public class BuildingManager : MonoBehaviour
{
    [SerializeField] private MeshRenderer[] _mesh;
    [SerializeField] private Material[]     _mat = new Material[2];
    [SerializeField] private GameObject[]   _protoTypeLocation;
    [SerializeField] private GameObject     _character;

    private LatLng _latLng;

    public string[] Destination_Name;
    public string Location_Name;

    private void Start()
    {
        Invoke("GetMesh", 1f);
    }

    // 건물에 메쉬, 콜라이더, 네비판단태그를 넣는다.
    private void GetMesh()
    {
        _mesh = GetComponentsInChildren<MeshRenderer>();
        _latLng = new LatLng((double)_latLng.Lat, (double)_latLng.Lng);

        foreach (var renderer in _mesh)
        {
            renderer.materials = _mat;
            renderer.gameObject.AddComponent<MeshCollider>();
            renderer.gameObject.AddComponent<NavMeshSourceTag>();
        }

        FindBuilding();
        AddCharacter();
    }

    public void OnLoaded(MapLoadedArgs args)
    {

    }

    // 빌딩의 이름과 위치를 받아오고, 그 위치를 기준으로 오브젝트 생성
    private void FindBuilding()
    {
        GameObject BuildingForLocation = GameObject.Find(Location_Name);
        Vector3 LocationPos = BuildingForLocation.transform.position;

        Instantiate(_protoTypeLocation[0], new Vector3(LocationPos.x - 5, 0.5f, LocationPos.z - 12), Quaternion.Euler(0, 0, 0));
        Instantiate(_protoTypeLocation[1], new Vector3(LocationPos.x + 17, 0.5f, LocationPos.z - 18), Quaternion.Euler(0, 0, 0));
        Instantiate(_protoTypeLocation[2], new Vector3(LocationPos.x + 43, 0.5f, LocationPos.z + 86), Quaternion.Euler(0, 0, 0));
        Instantiate(_protoTypeLocation[3], new Vector3(LocationPos.x + 50, 0.5f, LocationPos.z + 106), Quaternion.Euler(0, 0, 0));
    }

    // 아래 함수는 캐릭터 생성하는 테스트 함수. 추후에 게임매니저로 이동 가능.
    private void AddCharacter()
    {
        Instantiate(_character, new Vector3(-24.58f, 0.5f, 21.37f), Quaternion.identity);
    }
}

