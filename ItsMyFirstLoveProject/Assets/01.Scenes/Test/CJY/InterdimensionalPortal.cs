using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class InterdimensionalPortal : MonoBehaviour
{
    //��Ż �ȿ��� ����ų� ������ ��ä�� ��Ʈ�����
    [SerializeField] private Material[]     _materials;

    void Start()
    {
        Debug.Log("�÷��̾ ����");
        foreach (var mat in _materials)
        {
            ObjectMaskSetNotEqual();
        }
    }
    /// <summary>
    ///�ݶ��̴��� z������ ����ؼ� ��Ż���� �Ÿ� ����
    ///����ũ �������� ����ũ�� ���� ���̰ų� �Ⱥ��̰ų�
    ///Equal, ��Ż �� �ٱ����� ������Ʈ�� ����
    ///NotEqual ��Ż �ȿ�����  ������Ʈ�� ����
    /// </summary>
    private void OnTriggerStay(Collider other)
    {
        if (!other.CompareTag("Player")) return;

        //��Ż�����ϴ� ������ 0.001�̶� ��Ż z�ຸ�� �ڷΰ������� d
        if (transform.position.z >= other.transform.position.z)
        {
            Debug.Log("�÷��̾ �Ա���");
            ObjectMaskSetNotEqual();
        }
        else
        {
            Debug.Log("�÷��̾ ������");
            ObjectMaskSetEqual();
        }
    }


    void ObjectMaskSetEqual()
    {
        foreach (var mat in _materials)
        {
            mat.SetInt("_StencilComp", (int)CompareFunction.Equal);
            mat.SetInt("_PreStencilComp", (int)CompareFunction.Equal);
            mat.SetInt("_OutlineStencilComp", (int)CompareFunction.Equal);
        }
    }

    void ObjectMaskSetNotEqual()
    {
        foreach (var mat in _materials)
        {
            mat.SetInt("_StencilComp", (int)CompareFunction.NotEqual);
            mat.SetInt("_PreStencilComp", (int)CompareFunction.NotEqual);
            mat.SetInt("_OutlineStencilComp", (int)CompareFunction.NotEqual);
        }
    }
}
