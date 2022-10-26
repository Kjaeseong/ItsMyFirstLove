using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : SingletonBehaviour<GameManager>
{
    private AudioManager _audio;
    private CsvManager _csv;
    private SceneChanger _scene;

    public float CameraHeight { get; private set; }
    public float MapRotateY { get; private set; }
    public double Lat { get; private set; }
    public double Long { get; private set; }
    public float Azimuth { get; private set; }

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        _audio = GetComponentInChildren<AudioManager>();
        _csv = GetComponentInChildren<CsvManager>();
        _scene = GetComponentInChildren<SceneChanger>();
    }

    /// <summary>
    /// 지구 방위 기준 위도, 경도, 자북방위각 저장 <br/>
    /// lat : 위도 <br/>
    /// lng : 경도 <br/>
    /// azi : 자북방위각
    /// </summary>
    public void SetEarthPos(double lat, double lng, float azi)
    {
        Lat = lat;
        Long = lng;
        Azimuth = azi;
    }

    /// <summary>
    /// 실제 지면으로부터의 카메라 높이 저장
    /// </summary>
    public void SetCameraHeight(float Height)
    {
        CameraHeight = Height;
    }

    /// <summary>
    /// 현재 맵의 회전 각도(y축) 저장
    /// </summary>
    public void SetMapRotateY(float rotateY)
    {
        MapRotateY = rotateY;
    }
}
