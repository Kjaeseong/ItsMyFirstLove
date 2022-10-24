using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProtoTypeHanaMovement : MonoBehaviour
{
    private enum MoveStep
    {
        IDLE,
        WALK,
        RUN
    }
    [SerializeField] private GameObject _targetPosition;
    private Animator _anim;

    [SerializeField][Range(0, 20)] private float _walkSpeed;
    [SerializeField][Range(0, 20)] private float _runSpeed;
    private float _moveSpeed;
    private int _moveStep;
    private bool _isMoving;

    private void Start() 
    {
        _anim = GetComponentInChildren<Animator>();
    }

    private void Update() 
    {
        MoveToTarget();
    }

    public void SetBool()
    {
        if(_isMoving)
        {
            _isMoving = false;
        }
        else
        {
            _isMoving = true;
        }
    }

    private void MoveToTarget()
    {
        Vector3 target = new Vector3(_targetPosition.transform.position.x, 0f, _targetPosition.transform.position.z);
        Vector3 charpos = new Vector3(transform.position.x, 0f, transform.position.z);
        if(Vector3.Distance(target, charpos) > 0.5)
        {
            if(_isMoving == true)
            {
                if(Vector3.Distance(target, charpos) > 5)
                {
                    MoveRun();
                }
                else
                {
                    MoveWalk();
                }
                
                PlayAnim("MOVE");
                RotateTo(_targetPosition);

                transform.Translate(0f, 0f, _moveSpeed * Time.deltaTime);
            }
        }
        else
        {
            _isMoving = false;
            IDLE();
            PlayAnim("MOVE");
        }
        
    }

    private void MoveWalk()
    {
        _moveSpeed = _walkSpeed;
        _moveStep = (int)MoveStep.WALK;
    }

    private void MoveRun()
    {
        _moveSpeed = _runSpeed;
        _moveStep = (int)MoveStep.RUN;
    }

    private void IDLE()
    {
        _moveSpeed = 0f;
        _moveStep = (int)MoveStep.IDLE;

        RotateTo(Camera.main.gameObject);
    }

    /// <summary>
    /// type : "WALK", "RUN", "MOVE" 중에서 선택 입력
    /// </summary>
    public void PlayAnim(string type)
    {
        switch(type)
        {
            case "KISS":
                ILoveYouHanaChanKissMeBabeMyDarling();
                break;
            case "NO":
                _anim.SetTrigger("NO");
                break;
            case "MOVE":
                _anim.SetInteger("MoveStep", _moveStep);
                break;
        }
    }

    private void ILoveYouHanaChanKissMeBabeMyDarling()
    {
        _anim.SetTrigger("KISS");
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


    

}
