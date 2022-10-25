using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : SingletonBehaviour<GameManager>
{
    private AudioManager _audio;
    private CsvManager _csv;
    
    public float CameraHeight { get; private set; }
    public float MapRotateY { get; private set; }
    public double Lat { get; private set; }
    public double Long { get; private set; }




    public void SetRatLong(double lat, double lng)
    {
        Lat = lat;
        Long = lng;
    }

    public void SetCameraHeight(float Height)
    {
        CameraHeight = Height;
    }

    public void SetMapRotateY(float rotateY)
    {
        MapRotateY = rotateY;
    }

}
