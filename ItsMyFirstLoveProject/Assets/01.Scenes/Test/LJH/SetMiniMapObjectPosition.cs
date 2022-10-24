using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetMiniMapObjectPosition : MonoBehaviour
{
    [SerializeField] private Transform _miniMapCamera;
    [SerializeField] private Transform _miniMapRedCircle;

    private float _cameraHeight = 200f;
    private float _redCircleHeight = 100f;

    private void Update()
    {
        SetCameraPosition();
        SetRedCirclePosition();
    }
    // 미니맵 카메라의 위치 세팅
    private void SetCameraPosition()
    {
        _miniMapCamera.position = new Vector3(
            Camera.main.transform.position.x,
            Camera.main.transform.position.y + _cameraHeight,
            Camera.main.transform.position.z);
    }

    // 미니맵 플레이어 위치표시 오브젝트의 위치 세팅
    private void SetRedCirclePosition()
    {
        _miniMapRedCircle.position = new Vector3(
            Camera.main.transform.position.x,
            Camera.main.transform.position.y + _redCircleHeight,
            Camera.main.transform.position.z);

        _miniMapRedCircle.rotation = Quaternion.Euler(0f, Camera.main.transform.rotation.eulerAngles.y, 0f);
    }
}
