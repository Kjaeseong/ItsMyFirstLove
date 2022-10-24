using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetMiniMapObjectPosition : MonoBehaviour
{
    [SerializeField]
    private Transform _miniMapCamera;
    [SerializeField]
    private Transform _miniMapRedCircle;

    private void Update()
    {
        SetCameraPosition();
        SetRedCirclePosition();
    }
    private void SetCameraPosition()
    {
        _miniMapCamera.position = new Vector3(
            Camera.main.transform.position.x,
            Camera.main.transform.position.y + 200f,
            Camera.main.transform.position.z);
    }

    private void SetRedCirclePosition()
    {
        _miniMapRedCircle.position = new Vector3(
            Camera.main.transform.position.x,
            Camera.main.transform.position.y + 100f,
            Camera.main.transform.position.z);
        _miniMapRedCircle.rotation = Quaternion.Euler(0f, Camera.main.transform.rotation.eulerAngles.y, 0f);
    }
}
