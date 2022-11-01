using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Google.Maps.Coord;
using Google.Maps.Event;
using Google.Maps.Examples.Shared;
using UnityEngine.SceneManagement;

public class BuildingManager : MonoBehaviour
{
    [SerializeField] private MeshRenderer[] _mesh;
    [SerializeField] private Material[]     _mat = new Material[2];
    [SerializeField] private GameObject     _miniMapBuildingObject;

    private GameObject _miniMapBuilding;
    private LatLng _latLng;


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
            if (_miniMapBuilding.name[0] == 'E')
            {
                _miniMapBuilding.tag = "Building";
            }
            _miniMapBuilding.layer = 8;
            Instantiate(_miniMapBuilding, _miniMapBuildingObject.transform);
            renderer.gameObject.layer = 0;
            renderer.materials = _mat;
            renderer.gameObject.AddComponent<MeshCollider>();
            renderer.gameObject.AddComponent<NavMeshSourceTag>();
        }
    }

    public void OnLoaded(MapLoadedArgs args)
    {

    }

    

}

