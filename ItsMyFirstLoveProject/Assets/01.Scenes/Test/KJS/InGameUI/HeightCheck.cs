using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class HeightCheck : MonoBehaviour
{
    [SerializeField] private GameObject _checkPlane;
    [SerializeField] private GameObject _normalPlane;
    private ARRaycastManager _arRaycaster;
    private ARPlaneManager _arPlaneManager;
    private float _rayPositionY;
    private float _camPositionY;
    private float _cameraH;

    private bool _detectionPlane;

    void Start()
    {
        GameObject AR = Camera.main.gameObject;
        _arRaycaster = AR.GetComponentInParent<ARRaycastManager>();
        _arPlaneManager = AR.GetComponentInParent<ARPlaneManager>();
    }

    private void OnEnable() 
    {
        PlanePrefabSet(_checkPlane);
        _cameraH = 0f;
    }

    private void OnDisable() 
    {
        PlanePrefabSet(_normalPlane);
    }

    private void Update() 
    {
        DetectionHeight();
    }

    private void DetectionHeight()
    {
        RaycastToPlane();
        _camPositionY = Camera.main.transform.position.y;
        _cameraH = _camPositionY - _rayPositionY;

        if(1 <= _cameraH && _cameraH <= 2.5)
        {
            _detectionPlane = true;
        }
        else
        {
            _detectionPlane = false;
        }
    }

    private void RaycastToPlane()
    {
        List<ARRaycastHit> hits = new List<ARRaycastHit>();
        if(_arRaycaster.Raycast(Camera.main.transform.forward, hits, TrackableType.Planes))
        {
            Pose LastHit = hits[hits.Count - 1].pose;
            _rayPositionY = LastHit.position.y;
        }
    }

    private void PlanePrefabSet(GameObject plane)
    {
        _arPlaneManager.planePrefab = plane;
    }

    /// <summary>
    /// 체커에서 측정중인 카메라 높이를 반환받기 위한 함수
    /// </summary>
    public float GetHeight() => _cameraH;

    /// <summary>
    /// 적절한 높이에서 Plane이 인식되는지 반환해주는 함수
    /// </summary>
    public bool DetectionPlane() => _detectionPlane;


}
