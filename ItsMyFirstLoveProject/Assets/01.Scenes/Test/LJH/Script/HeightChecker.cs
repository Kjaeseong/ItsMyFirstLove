using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class HeightChecker : MonoBehaviour
{
    [SerializeField] private ARRaycastManager _arRaycaster;
    [SerializeField] private GameObject _map;

    private float _rayPositionY;
    private float _camPositionY;
    private float _cameraH;

    public float GetRayHitPositionY()
    {
        return _rayPositionY;
    }

    public float GetCameraPositionY()
    {
        return _camPositionY;
    }

    public float GetDistCamToPlane()
    {
        return _cameraH;
    }


    private void Update()
    {
        DetectionHeight();
    }

    private void DetectionHeight()
    {
        CameraPositionCheck();
        RaycastToPlane();
        _cameraH = _camPositionY - _rayPositionY;
    }


    private void RaycastToPlane()
    {
        List<ARRaycastHit> hits = new List<ARRaycastHit>();
        if (_arRaycaster.Raycast(Camera.main.transform.forward, hits, TrackableType.Planes))
        {
            Pose LastHit = hits[hits.Count - 1].pose;
            _rayPositionY = LastHit.position.y;
        }
    }

    private void CameraPositionCheck()
    {
        _camPositionY = Camera.main.transform.position.y;
    }

    public void DetectionSuccess()
    {
        gameObject.SetActive(false);
    }

    public void PositionSet()
    {
        _map.transform.position = new Vector3(
            _map.transform.position.x,
            -1 * _cameraH,
            _map.transform.position.z);
    }
}