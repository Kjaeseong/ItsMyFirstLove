using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum MoveStep
{
    IDLE,
    WALK,
    RUN
}

public class AnimationSupport : MonoBehaviour
{
    private Animator _anim;
    private ProtoTypeHanaMovement _move;
    
    private void Start() 
    {
        _anim = GetComponent<Animator>();
        _move = GetComponentInParent<ProtoTypeHanaMovement>();
    }

    /// <summary>
    /// method : "Move", "Kiss", "No"
    /// </summary>
    public void Play(string method)
    {
        Invoke(method, 0f);
    }

    private void Move()
    {
        //_anim.SetInteger("MoveStep", _move.GetMoveStep());
        _anim.SetInteger("MoveStep", 1);
    }

    private void MoveRun()
    {
        _anim.SetInteger("MoveStep", 2);
    }

    private void Idle()
    {
        _anim.SetInteger("MoveStep", 0);
    }

    private void Kiss()
    {
        ILoveYouHanaChanKissMeBabeMyDarling();
        //_anim.SetTrigger("KISS");
    }

    private void ILoveYouHanaChanKissMeBabeMyDarling()
    {
        _anim.SetTrigger("KISS");
    }

    private void No()
    {
        _anim.SetTrigger("NO");
    }

}
