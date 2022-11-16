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
    [SerializeField] private int _zoom = 18;

    private int _mapWidth = 640;
    private int _mapHeight = 640;

    [SerializeField] private MapType _mapType = MapType.roadmap;

    [Range(1, 4)]
    [SerializeField] private int _scale = 1;

    [SerializeField] private float[] _markerLat;
    [SerializeField] private float[] _markerLon;

    [SerializeField] private MarkerSize _giftMarkerSize = MarkerSize.mid;
    [SerializeField] private MarkerColor _giftMarkerColor = MarkerColor.red;

    [SerializeField] private MarkerSize _playerMarkerSize = MarkerSize.tiny;
    [SerializeField] private MarkerColor _playerMarkerColor = MarkerColor.brown;

    [SerializeField] private string _apiKey;


    IEnumerator Map()
    {
        _url = "https://maps.googleapis.com/maps/api/staticmap"
           + "?center=" + _mapCenterLat + "," + _mapCenterLon
           + "&zoom=" + _zoom
           + "&size=" + _mapWidth + "x" + _mapHeight
           + "&scale=" + _scale
           + "&maptype=" + _mapType
           + "&markers=size:" + _playerMarkerSize
           + "%7Ccolor:" + _playerMarkerColor
           + "%7C" + _mapCenterLat + "," + _mapCenterLon
           + "&markers=size:" + _giftMarkerSize
           + "%7Ccolor:" + _giftMarkerColor 
           + "%7C" + _markerLat[0] + "," + _markerLon[0]
           + "&markers=size:" + _giftMarkerSize
           + "%7Ccolor:" + _giftMarkerColor
           + "%7C" + _markerLat[1] + "," + _markerLon[1]
           + "&markers=size:" + _giftMarkerSize
           + "%7Ccolor:" + _giftMarkerColor
           + "%7C" + _markerLat[2] + "," + _markerLon[2]
           + "&markers=size:" + _giftMarkerSize
           + "%7Ccolor:" + _giftMarkerColor
           + "%7C" + _markerLat[3] + "," + _markerLon[3]
           + "&markers=size:" + _giftMarkerSize
           + "%7Ccolor:" + _giftMarkerColor
           + "%7C" + _markerLat[4] + "," + _markerLon[4]
           + "&markers=size:" + _giftMarkerSize
           + "%7Ccolor:" + _giftMarkerColor
           + "%7C" + _markerLat[5] + "," + _markerLon[5]
           + "&markers=size:" + _giftMarkerSize
           + "%7Ccolor:" + _giftMarkerColor
           + "%7C" + _markerLat[6] + "," + _markerLon[6]
           + "&markers=size:" + _giftMarkerSize
           + "%7Ccolor:" + _giftMarkerColor
           + "%7C" + _markerLat[7] + "," + _markerLon[7]
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
