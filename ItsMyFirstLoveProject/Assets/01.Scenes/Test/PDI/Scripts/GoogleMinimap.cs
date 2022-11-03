using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class GoogleMinimap : MonoBehaviour
{
    public enum MapType
    {
        roadmap, satellite, terrain, hybird,
    }

    public enum MarkerSize
    {
        tiny, mid, small, big,
    }

    public enum MarkerColor
    {
        black, brown, green, purple, yellow, blue, gray, orange, red, white,
    }

    private RawImage _image;

    [SerializeField] private string _url;

    [SerializeField] private float _mapCenterLat;
    [SerializeField] private float _mapCenterLon;

    [Range(1, 20)]
    [SerializeField] private int _zoom = 14;

    private int _mapWidth = 640;
    private int _mapHeight = 640;

    [SerializeField] private MapType _mapType = MapType.roadmap;

    [Range(1, 4)]
    [SerializeField] private int _scale = 1;

    [SerializeField] private float _markerLat;
    [SerializeField] private float _markerLon;

    [SerializeField] private MarkerSize _markerSize = MarkerSize.mid;
    [SerializeField] private MarkerColor _markerColor = MarkerColor.blue;

    [SerializeField] private char _label = 'S';
    [SerializeField] private string _apiKey;


    IEnumerator Map()
    {
        _label = char.ToUpper(_label);

        _url = "https://maps.googleapis.com/maps/api/staticmap"
           + "?center=" + _mapCenterLat + "," + _mapCenterLon
           + "&zoom=" + _zoom
           + "&size=" + _mapWidth + "x" + _mapHeight
           + "&scale=" + _scale
           + "&maptype=" + _mapType
           + "&markers=size:" + _markerSize
           + "%7Ccolor:" + _markerColor 
           + "%7Clabel:" + _label 
           + "%7C" + _markerLat + "," + _markerLon
           + "&key=" + _apiKey;

        using (UnityWebRequest uwr = UnityWebRequestTexture.GetTexture(_url))
        {
            yield return uwr.SendWebRequest();

            if (uwr.result != UnityWebRequest.Result.Success)
            {
                Debug.Log(uwr.error);
            }
            else
            {
                _image.texture = DownloadHandlerTexture.GetContent(uwr);
            }
        }
    }

    private void Start()
    {
        Reset();
    }

    private void Reset()
    {
        _image = GetComponentInChildren<RawImage>();
        RefreshMap();
    }

    public void RefreshMap()
    {
        if (true == gameObject.activeInHierarchy)
        {
            StartCoroutine(Map());
        }
    }
#if UNITY_EDITOR
    private void OnValidate()
    {
        RefreshMap();
    }
#endif
}
