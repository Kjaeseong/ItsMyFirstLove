using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProtoTypeHanaMovement : MonoBehaviour
{
    [SerializeField] private GameObject _targetPosition;
    private AnimationSupport _anim;

    [SerializeField][Range(0, 20)] private float _walkSpeed;
    [SerializeField][Range(0, 20)] private float _runSpeed;
    private float _moveSpeed;
    private int _moveStep;
    private bool _canMove;

    private void Start() 
    {
        _anim = GetComponentInChildren<AnimationSupport>();
    }

    private void Update() 
    {
        MoveToTarget(_canMove);
    }

    public void SetCanMove()
    {
        if(_canMove)
        {
            _canMove = false;
        }
        else
        {
            _canMove = true;
        }
    }

    private void MoveToTarget(bool canMove)
    {
        if(canMove == true)
        {
            Vector2 target = new Vector2(
                _targetPosition.transform.position.x, 
                _targetPosition.transform.position.z
            );
            Vector2 charPos = new Vector2(
                transform.position.x, 
                transform.position.z
            );
            float DistToTarget = Vector2.Distance(target, charPos);
            
            if(DistToTarget > 0.5f)
            {
                if(DistToTarget > 1.5f)
                {
                    MoveSet((int)MoveStep.RUN);
                }
                else
                {
                    MoveSet((int)MoveStep.WALK);
                }
                _anim.Play("Move");
            }
            else
            {
                _canMove = false;
                MoveSet((int)MoveStep.IDLE);
                _anim.Play("Move");
            }
        }
    }

    private void MoveSet(int state)
    {
        switch(state)
        {
            case 0:
                _moveSpeed = 0f;
                break;
            case 1:
                _moveSpeed = _walkSpeed;
                break;
            case 2:
                _moveSpeed = _runSpeed;
                break;
        }

        _moveStep = state;
        
        if(state != 0)
        {
            transform.Translate(0f, 0f, _moveSpeed * Time.deltaTime);
            RotateTo(_targetPosition);
        }
        else
        {
            RotateTo(Camera.main.gameObject);
        }
    }

    private void RotateTo(GameObject target)
    {
        Vector3 targetPos = new Vector3(
            target.transform.position.x,
            transform.position.y,
            target.transform.position.z
        );
        transform.LookAt(targetPos);
    }

    public int GetMoveStep() => _moveStep;

    public void SetPosY(float y)
    {
        transform.position = new Vector3(
            transform.position.x,
            y,
            transform.position.z
        );
    }
}
