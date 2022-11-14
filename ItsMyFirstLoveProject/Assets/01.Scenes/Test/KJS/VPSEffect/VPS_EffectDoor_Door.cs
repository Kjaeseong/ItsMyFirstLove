using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VPS_EffectDoor_Door : MonoBehaviour
{
    [SerializeField] private GameObject _door;
    [SerializeField] private float _doorSpeed;
    private int _moveDirection;

    private float DistToAR()
    {
        return Vector3.Distance(Camera.main.transform.position, transform.position);
    }

    private void RotationDoor(int direction)
    {
        
    }


}
