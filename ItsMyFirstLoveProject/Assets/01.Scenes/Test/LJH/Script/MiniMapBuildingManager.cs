using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Google.Maps.Coord;
using Google.Maps.Event;
using Google.Maps.Examples.Shared;
using UnityEngine.SceneManagement;

public class MiniMapBuildingManager : MonoBehaviour
{
    [SerializeField] private Transform[] _miniMapBuilding;
    [SerializeField] private GameObject _miniMapBuildingObject;
    
    public void SetMiniMapBuildingsOption()
    {
        _miniMapBuilding = GetComponentsInChildren<Transform>();

        foreach (var building in _miniMapBuilding)
        {
            building.gameObject.layer = 8;
        }
    }
}

