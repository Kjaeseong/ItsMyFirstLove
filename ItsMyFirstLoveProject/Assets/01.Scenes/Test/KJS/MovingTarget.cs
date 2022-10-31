using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingTarget : MonoBehaviour
{
    private enum SideDirection
    {
        LEFT = -1,
        RIGHT = 1
    }
    
    [SerializeField][Range(0, 5)] private float _rangeX;
    [SerializeField][Range(0, 5)] private float _rangeZ;

    private TargetPositionChecker _checker;

    private int _direction = (int)SideDirection.RIGHT;

    private void Start() 
    {
        _checker = GetComponentInParent<TargetPositionChecker>();   
    }

    private void OnTriggerEnter(Collider other) 
    {
        if(other.name == "Building")
        {
            if(_direction == (int)SideDirection.LEFT)
            {
                _direction = (int)SideDirection.RIGHT;
            }
            else if(_direction == (int)SideDirection.RIGHT)
            {
                _direction = (int)SideDirection.LEFT;
            }
        }
    }

    private void Update() 
    {
        if(_checker.GetIsMove())
        {
            transform.localPosition = new Vector3(
                _rangeX * _direction,
                transform.localPosition.y,
                _rangeZ
            );
        }
        else
        {
            transform.localPosition = new Vector3(
                _rangeX * _direction,
                transform.localPosition.y,
                1f
            );
        }
        
    }
}
