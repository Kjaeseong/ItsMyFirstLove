using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Google.Maps.Coord;
using Google.Maps.Event;
using Google.Maps.Examples.Shared;

public class BuildingManager : MonoBehaviour
{
    [SerializeField]
    private MeshRenderer[] _mesh;

    [SerializeField]
    private Material[] _mat = new Material[2];

    private LatLng _latLng;

    public string[] Destination_Name;
    public string Location_Name;

    private void Start()
    {
        Invoke("GetMesh", 1f);
    }

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
    }

    public void OnLoaded(MapLoadedArgs args)
    {

    }

    private void FindBuilding()
    {
        GameObject[] BuildingsOfName = new GameObject[Destination_Name.Length];
        Vector3[] BuildingsOfNamePosition = new Vector3[Destination_Name.Length];

        GameObject BuildingForLocation = GameObject.Find(Location_Name);
        Vector3 LocationPos = BuildingForLocation.transform.position;
    }
}

