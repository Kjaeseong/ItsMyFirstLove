using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : SingletonBehaviour<GameManager>
{
    private AudioManager _audio;
    private CsvManager _csv;
    public SceneChanger _scene { get; private set; }
    
    [field: SerializeField] public GameObject Map { get; private set; }

    // 지도/위치 관련 변수              ----------------
    public float CameraHeight { get; private set; }
    public float MapRotateY { get; private set; }
    public double Lat { get; private set; }
    public double Long { get; private set; }
    public float Azimuth { get; private set; }

    // 케릭터 및 플레이어 관련 변수     ----------------
    public float LoveGauge { get; private set; }
    public float Level { get; private set; }
    public bool _isActCharacterWalkMode { get; private set; }
    public GameObject _characterModel { get; private set; }


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

    /// <summary>
    /// 현재 맵의 회전 각도(y축)를 더함
    /// </summary>
    public void AddMapRotateY(float rotateY)
    {
        MapRotateY += rotateY;
    }

    /// <summary>
    /// 산책 모드에서 케릭터 활성화 여부
    /// </summary>
    public void ActivateCharacterInWalk()
    {
        if(_isActCharacterWalkMode)
        {
            _isActCharacterWalkMode = false;
        }
        else
        {
            _isActCharacterWalkMode = true;
        }

        _characterModel.transform.position = new Vector3(
            Camera.main.transform.position.x,
            Camera.main.transform.position.y - 1.3f,
            Camera.main.transform.position.z + 4f);

        _characterModel.SetActive(_isActCharacterWalkMode);
    }
    public void SetCharObject(GameObject Char)
    {
        _characterModel = Char;
    }

    /// <summary>
    /// GameObject 타입 프로퍼티에 오브젝트를 넣어주기 위한 함수 <br/>
    /// name : 프로퍼티(변수) 명 <br/>
    /// object : gameObject
    /// </summary>
    public void SetObjectProperty(string name, GameObject Object)
    {
        //GameObject temp
        //GetType().GetField(name).GetValue(Object);
        // TODO : 방법 찾아야 함..분명 있을것같음
    }

}
