using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinChecker : MonoBehaviour
{
    [SerializeField] private GameObject _miniMapCam;

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(
            Camera.main.transform.position.x,
            190,
            Camera.main.transform.position.z
        );

        transform.rotation = Quaternion.Euler(
            transform.rotation.eulerAngles.x,
            Camera.main.transform.rotation.eulerAngles.y,
            transform.rotation.eulerAngles.z
        );

        _miniMapCam.transform.position = new Vector3(
            transform.position.x,
            310,
            transform.position.z
        );
    }
}
