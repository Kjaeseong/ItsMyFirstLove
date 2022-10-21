using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeAnim : MonoBehaviour
{
    public GameObject       Char;

    private int             _randNum;
    private Animator        _animator;
    private void Start()
    {
        _animator = Char.GetComponent<Animator>();
    }

    //클릭시 애니메이션을 랜덤하게 바꾼다.
    public void AnimChanger()
    {
        _randNum = Random.Range(0, 3);

        _animator.SetInteger("RandNum", _randNum);
        _animator.SetTrigger("Click");
        Debug.Log(_randNum);
        _randNum = 0;
    }

}
