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
    [SerializeField] private Material[] _mat = new Material[2];
    [SerializeField] private GameObject _miniMapBuildingObject;

    private GameObject _miniMapBuilding;

    private void Start()
    {
        
    }

    // 건물에 메쉬, 콜라이더, 네비판단태그를 넣는다.
    public void SetBuildingsOption()
    {
        _mesh = GetComponentsInChildren<MeshRenderer>();

        foreach (var renderer in _mesh)
        {
            _miniMapBuilding = renderer.gameObject;
            if (_miniMapBuilding.name[0] == 'E')
            {
                _miniMapBuilding.tag = "Building";
            }

            renderer.materials = _mat;
            renderer.gameObject.AddComponent<MeshCollider>();
            renderer.gameObject.AddComponent<NavMeshSourceTag>();
        }
    }
}

