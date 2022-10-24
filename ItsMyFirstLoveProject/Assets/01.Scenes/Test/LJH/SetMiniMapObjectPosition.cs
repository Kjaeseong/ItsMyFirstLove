using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetMiniMapObjectPosition : MonoBehaviour
{
    [SerializeField]
    private Transform _miniMapCamera;
    [SerializeField]
    private Transform _miniMapRedCircle;

    private float _cameraHeight = 200f;
    private float _redCircleHeight = 100f;

    private void Update()
    {
        SetCameraPosition();
        SetRedCirclePosition();
    }
    private void SetCameraPosition()
    {
        _miniMapCamera.position = new Vector3(
            Camera.main.transform.position.x,
            Camera.main.transform.position.y + _cameraHeight,
            Camera.main.transform.position.z);
    }

    private void SetRedCirclePosition()
    {
        _miniMapRedCircle.position = new Vector3(
            Camera.main.transform.position.x,
            Camera.main.transform.position.y + _redCircleHeight,
            Camera.main.transform.position.z);

        _miniMapRedCircle.rotation = Quaternion.Euler(0f, Camera.main.transform.rotation.eulerAngles.y, 0f);
    }
}
