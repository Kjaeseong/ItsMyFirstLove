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
        _randNum = Random.Range(0,3);

        Debug.Log(_randNum);

        switch (_randNum)
        {
            case 0:
                _animator.SetTrigger("KISS");
                break;
            case 1:
                _animator.SetTrigger("NO");
                break;
        }
    }

}
