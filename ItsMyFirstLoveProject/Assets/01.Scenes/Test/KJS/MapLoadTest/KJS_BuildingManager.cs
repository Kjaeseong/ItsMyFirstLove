using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Google.Maps.Coord;
using Google.Maps.Event;
using Google.Maps.Examples.Shared;

public class KJS_BuildingManager : MonoBehaviour
{
    [SerializeField] private MeshRenderer[] _mesh;
    [SerializeField] private Material[] _mat = new Material[2];
    [SerializeField] private GameObject     _miniMapBuildingObject;
    private GameObject _miniMapBuilding;
    private LatLng _latLng;

    public Vector3 TestPos;
    public string LocationName;


    private GameObject _startBuilding;
    [SerializeField] private GameObject _player;

    Quaternion rot;




    private void Start()
    {
        //Invoke("GetMesh", 1f);
    }

    // 건물에 메쉬, 콜라이더, 네비판단태그를 넣는다.
    public void GetMesh()
    {
        _mesh = GetComponentsInChildren<MeshRenderer>();
        _latLng = new LatLng((double)_latLng.Lat, (double)_latLng.Lng);

        foreach (var renderer in _mesh)
        {
            _miniMapBuilding = renderer.gameObject;
            
            renderer.materials = _mat;

            if(renderer.name == "ExtrudedStructure (ChIJl-L0HlWlfDURRtr_nkpNSdc)")
            {
                _startBuilding = renderer.gameObject;
            }

            
            
        }
        Vector3 dir = _startBuilding.transform.position - Camera.main.transform.position;
        dir.y = 0f;
        rot = Quaternion.LookRotation(dir.normalized);
        _player.transform.rotation = rot;
        transform.RotateAround(
            Camera.main.transform.position, 
            Vector3.up, 
            -1 * _player.transform.rotation.eulerAngles.y
        );

    } 

    public void OnLoaded(MapLoadedArgs args)
    {

    }

    // 빌딩의 이름과 위치를 받아오고, 그 위치를 기준으로 오브젝트 생성
    public void FindBuilding()
    {
        GameObject BuildingForLocation = GameObject.Find(LocationName);
        Vector3 LocationPos = BuildingForLocation.transform.position;
    }


    private void Update() 
    {
    }
}

