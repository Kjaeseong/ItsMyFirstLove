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

    private void MoveToTarget()
    {

        Debug.Log(Vector3.Distance(_targetPosition.transform.position, transform.position));
        if(Vector3.Distance(_targetPosition.transform.position, transform.position) > 1)
        {
            MoveWalk();
            PlayAnim("MOVE");
            RotateTo(_targetPosition);

            transform.Translate(0f, 0f, _moveSpeed * Time.deltaTime);
        }
        else
        {
            IDLE();
            PlayAnim("MOVE");
        }
        
    }

    private void MoveWalk()
    {
        _moveSpeed = _walkSpeed;
        _moveStep = (int)MoveStep.WALK;
    }

    private void MoveRUN()
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
                _anim.SetTrigger("KISS");
                break;
            case "NO":
                _anim.SetTrigger("NO");
                break;
            case "MOVE":
                _anim.SetInteger("MoveStep", _moveStep);
                break;
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


    

}
