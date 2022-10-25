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

    // �ǹ��� �޽�, �ݶ��̴�, �׺��Ǵ��±׸� �ִ´�.
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

    // ������ �̸��� ��ġ�� �޾ƿ���, �� ��ġ�� �������� ������Ʈ ����
    private void FindBuilding()
    {
        GameObject BuildingForLocation = GameObject.Find(Location_Name);
        Vector3 LocationPos = BuildingForLocation.transform.position;

        Instantiate(_protoTypeLocation[0], new Vector3(LocationPos.x - 5, 0.5f, LocationPos.z - 12), Quaternion.Euler(0, 0, 0));
        Instantiate(_protoTypeLocation[1], new Vector3(LocationPos.x + 17, 0.5f, LocationPos.z - 18), Quaternion.Euler(0, 0, 0));
        Instantiate(_protoTypeLocation[2], new Vector3(LocationPos.x + 43, 0.5f, LocationPos.z + 86), Quaternion.Euler(0, 0, 0));
        Instantiate(_protoTypeLocation[3], new Vector3(LocationPos.x + 50, 0.5f, LocationPos.z + 106), Quaternion.Euler(0, 0, 0));
    }

    // �Ʒ� �Լ��� ĳ���� �����ϴ� �׽�Ʈ �Լ�. ���Ŀ� ���ӸŴ����� �̵� ����.
    private void AddCharacter()
    {
        Instantiate(_character, new Vector3(-24.58f, 0.5f, 21.37f), Quaternion.identity);
    }
}

