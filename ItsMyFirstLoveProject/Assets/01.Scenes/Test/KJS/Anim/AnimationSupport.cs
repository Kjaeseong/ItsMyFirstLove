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
        _anim.SetInteger("MoveStep", _move.GetMoveStep());
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
