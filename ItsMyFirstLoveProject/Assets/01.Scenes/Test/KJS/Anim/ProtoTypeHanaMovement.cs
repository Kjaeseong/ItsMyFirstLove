using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ProtoTypeHanaMovement : MonoBehaviour
{
    [SerializeField] private GameObject _targetPosition;
    private AnimationSupport _anim;

    [SerializeField][Range(0, 20)] private float _walkSpeed;
    [SerializeField][Range(0, 20)] private float _runSpeed;
    private float _moveSpeed;
    private int _moveStep;
    private bool _canMove;
    private float DistToTarget;

    private void Awake()
    {
        if (SceneManager.GetActiveScene().name == "Proto_WalkScene")
        {
            GameManager.Instance.SetCharObject(gameObject);
        }
    }

    private void Start() 
    {
        _anim = GetComponentInChildren<AnimationSupport>();
    }

    private void Update() 
    {
        GetDistToTarget();
        MoveToTarget(_canMove);

    }

    public void SetCanMove()
    {
        if(DistToTarget > 0.4f)
        {
            _canMove = true;
        }
        else
        {
            _canMove = false;
        }
    }


    private void GetDistToTarget()
    {
        Vector2 target = new Vector2(
                _targetPosition.transform.position.x, 
                _targetPosition.transform.position.z
            );
        Vector2 charPos = new Vector2(
                transform.position.x, 
                transform.position.z
            );

        DistToTarget = Vector2.Distance(target, charPos);
    }



    private void MoveToTarget(bool canMove)
    {
        SetCanMove();
        if(canMove == true)
        {
            if(DistToTarget > 0.5f)
            {
                if(DistToTarget > 1.5f)
                {
                    MoveSet((int)MoveStep.RUN);
                    _anim.Play("MoveRun");
                }
                else
                {
                    MoveSet((int)MoveStep.WALK);
                    _anim.Play("Move");
                }
            }
            else
            {
                MoveSet((int)MoveStep.IDLE);
                _anim.Play("Idle");
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
        
Debug.Log(_moveStep);
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
