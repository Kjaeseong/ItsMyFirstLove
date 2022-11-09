using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapCleaner : MonoBehaviour
{
    [SerializeField] private GameObject _map;

    public void ClearMap()
    {
        foreach(var go in _map.GetComponentsInChildren<GameObject>())
        {
            go.SetActive(false);
        }
    }

    public void ActiveMap()
    {
        foreach (var go in _map.GetComponentsInChildren<GameObject>())
        {
            if(go.activeSelf == false)
            go.SetActive(true);
        }
    }
}
