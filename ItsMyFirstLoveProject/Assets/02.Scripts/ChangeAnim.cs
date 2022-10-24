using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeAnim : MonoBehaviour
{
    //Ŭ���� ���� �ִϸ��̼� ����

    public GameObject       Char;

    private int             _randNum;
    private Animator        _animator;
    private void Start()
    {
        _animator = Char.GetComponent<Animator>();
    }

    //Ŭ���� �ִϸ��̼��� �����ϰ� �ٲ۴�.
    public void AnimChanger()
    {
        _randNum = Random.Range(1,3);

        _animator.SetInteger("RandNum", _randNum);
        _animator.SetTrigger("Click");
        Debug.Log(_randNum);
        _randNum = 0;
    }

}
