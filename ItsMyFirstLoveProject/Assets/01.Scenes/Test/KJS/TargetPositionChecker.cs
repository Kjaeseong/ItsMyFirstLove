using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetPositionChecker : MonoBehaviour
{    
    private enum Direction
    {
        LEFT = -1,
        CENTER,
        RIGHT
    }

    [SerializeField] private GameObject _player;
    [SerializeField] private GameObject _target;
    [SerializeField] private float _checkCycle;
    

    private Vector3 _nowPosition;
    private Vector3 _prevPosition;
    private float _nowDistance;
    private float _prevDistance;
    private bool _isSwitchOn;
    private int _direction;


    private void Start() 
    {
        MoveTargetSwitch(true);
        _direction = (int)Direction.RIGHT;
    }

    private void TargetPositionSet()
    {
        //_movingTarget.transform.position = transform.forward * 2;
    }

    private void MoveTargetSwitch(bool OnOff)
    {
        if(OnOff == true && _isSwitchOn == false)
        {
            _isSwitchOn = true;
            StartCoroutine(DistanceCheck());
        }
        else if(OnOff == false && _isSwitchOn == true)
        {
            _isSwitchOn = false;
            StopCoroutine(DistanceCheck());
        }
    }


    private IEnumerator DistanceCheck()
    {
        while(true)
        {
            
            _prevPosition = _nowPosition;
            _prevDistance = _nowDistance;
            _nowPosition = _player.transform.position;

            Vector3 dir = _nowPosition - _prevPosition;
            dir.y = 0f;
            _nowDistance = dir.magnitude;
            Quaternion rot = Quaternion.LookRotation(dir.normalized);

            Debug.Log(rot.eulerAngles);

            if(_nowDistance >= 0.01)
            {
                transform.SetPositionAndRotation(_player.transform.position, rot);
                TargetPositionSet();
            }
            else if(true)
            {

            }
            
            yield return new WaitForSeconds(_checkCycle);
        }
    }

}
