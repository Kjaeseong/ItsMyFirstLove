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
    private float DistToTarget;

    private TargetPositionChecker _positionChecker;

    private void Awake()
    {
        //GameManager.Instance.SetCharObject(gameObject);
        
    }

    private void Start() 
    {
        _positionChecker = _targetPosition.GetComponentInParent<TargetPositionChecker>();
        _anim = GetComponentInChildren<AnimationSupport>();
    }

    private void Update() 
    {
        GetDistToTarget();
        MoveToTarget(_canMove);
        transform.position = new Vector3(
            transform.position.x,
            Camera.main.transform.position.y - 1.3f,
            transform.position.z
        );

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
                if(DistToTarget > 2f)
                {
                    MoveSet((int)MoveStep.RUN);
                    _anim.Play("MoveRun");
                }
                else
                {
                    Debug.Log("----");
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

    // TODO : 케릭터 이동조건 추가 요함.
    private void MoveSet(int state)
    {
        Vector3 TargetPosition = new Vector3(
            _targetPosition.transform.position.x,
            transform.position.y,
            _targetPosition.transform.position.z
        );
        
        float distToTarget = Vector3.Distance(TargetPosition, transform.position);
        switch(state)
        {
            case 0:
                _moveSpeed = 0f;
                break;
            case 1:
                _moveSpeed = distToTarget;
                Debug.Log(_positionChecker.GetPlayerSpeed());

                break;
            case 2:
                _moveSpeed = distToTarget * 2;
                Debug.Log(_positionChecker.GetPlayerSpeed());
                break;
        }

        _moveStep = state;

        if(state != 0)
        {
            transform.Translate(0f, 0f, _moveSpeed * Time.deltaTime);
            RotateTo(_targetPosition);
            StopCoroutine(RotateToPlayerDontMove());
        }
        else
        {
            StartCoroutine(RotateToPlayerDontMove());
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

    private IEnumerator RotateToPlayerDontMove()
    {
        yield return new WaitForSeconds(2f);

        RotateTo(Camera.main.gameObject);
    }
}
