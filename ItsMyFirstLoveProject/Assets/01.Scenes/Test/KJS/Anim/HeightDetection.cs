using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class HeightDetection : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _TraycastingPosition;
    [SerializeField] private TextMeshProUGUI _TcameraPosition;
    [SerializeField] private TextMeshProUGUI _TcameraH;
    [SerializeField] private ARRaycastManager _arRaycaster;
    [SerializeField] private GameObject _ground;
    [SerializeField] private ProtoTypeHanaMovement _hana;

    private float _rayPositionY;
    private float _camPositionY;
    private float _cameraH;

    // TODO : 맵 내리고 활성화 해주는 함수 추가 요망
    private void OnDisable() 
    {
        Vector3 MapPosition = new Vector3(0f, -1 * _cameraH, 0f);
    }

    private void Update() 
    {
        DetectionHeight();
    }

    private void DetectionHeight()
    {
        CameraPositionCheck();
        RaycastToPlane();
        TextSet(_TcameraH, _cameraH.ToString());
        _cameraH = _camPositionY - _rayPositionY;
    }


    private void RaycastToPlane()
    {
        List<ARRaycastHit> hits = new List<ARRaycastHit>();
        if(_arRaycaster.Raycast(Camera.main.transform.forward, hits, TrackableType.Planes))
        {
            Pose LastHit = hits[hits.Count - 1].pose;
            _rayPositionY = LastHit.position.y;
            TextSet(_TraycastingPosition, LastHit.position.ToString());
        }
    }

    private void CameraPositionCheck()
    {
        _camPositionY = Camera.main.transform.position.y;

        TextSet(_TcameraPosition, Camera.main.transform.position.ToString());
    }

    private void TextSet(TextMeshProUGUI target, string Text)
    {
        target.text = Text;
    }

    public void DetectionSuccess()
    {
        //gameObject.SetActive(false);

        Vector3 MapPosition = new Vector3(0f, -1 * _cameraH, 0f);
        _ground.transform.position = MapPosition;
        _hana.SetPosY(-1 * _cameraH);
    }



}
