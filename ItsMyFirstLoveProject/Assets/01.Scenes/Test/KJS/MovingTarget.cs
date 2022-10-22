using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingTarget : MonoBehaviour
{
    private enum SideDirection
    {
        LEFT = -1,
        CENTER,
        RIGHT
    }

    private Vector3 _targetPosition;
    private int _sideDirection;
    private bool _buildingDetection;
    [SerializeField] private GameObject _player;
    [SerializeField] private float _distToPlayerRange;

    //어오 씨발 보통이 아니네










    
    [SerializeField] private float _angleRange = 120f;
    [SerializeField] private bool _insideAngle;



    private void OnTriggerEnter(Collider other) 
    {
        if(other.name == "Building")
        {
            BuildingDetection(other);
            _buildingDetection = true;
        }
    }

    private void OnTriggerExit(Collider other) 
    {
        _buildingDetection = false;
    }




    



    private void Update() 
    {
        InsideAngleCheck();
        SideMove();
        
        transform.rotation = _player.transform.rotation;



        
    }



    

    private void BuildingDetection(Collider other)
    {
        Quaternion targetRotation = Quaternion.LookRotation(
                other.transform.position - transform.position, 
                transform.up);

        //왼쪽에서 충돌했을 때
        if(targetRotation.y < 0)
        {
            _sideDirection = (int)SideDirection.RIGHT;
        }

        //오른쪽에서 충돌했을 때
        if(targetRotation.y > 0)
        {
            _sideDirection = (int)SideDirection.LEFT;
        }
    }

    private void SideMove()
    {
        if(_buildingDetection)
        {
            transform.Translate(_sideDirection * 1f, 0f, 0f);
        }
        else
        {
            if(!_insideAngle)
            {
                if(transform.position.x < _player.transform.position.x)
                {
                    transform.Translate(0.1f, 0f, 0f);
                }
                else if(transform.position.x > _player.transform.position.x)
                {
                    transform.Translate(-0.1f, 0f, 0f);
                }
            }
            else
            {

            }
            
        }

    }

    private void InsideAngleCheck()
    {
        Debug.Log("인사이드 앵글 체크");

        Vector3 dist = transform.position - _player.transform.position;

        if (dist.magnitude <= _distToPlayerRange + 1)
        {
            float dot = Vector3.Dot(dist.normalized, transform.forward);
            float theta = Mathf.Acos(dot);
            float degree = Mathf.Rad2Deg * theta;

            Debug.Log(degree);

            if (degree <= _angleRange)
            {
                _insideAngle = true;
            }
            else
            {
                _insideAngle = false;
            }
        }
        else
        {
            _insideAngle = false;
        }
    }


    private float DistanceToPlayer()
    {
        return Vector3.Distance(_player.transform.position, transform.position);
    }

    private void LocatedPlayer()
    {

    }

    private void LocatedDestination()
    {
        // TODO : 추후 경로시스템 완성시 함수 로직 추가 필요함.
        // 목적지 근접시 먼저 달려가게 하기 위해 필요함.
    }
}
