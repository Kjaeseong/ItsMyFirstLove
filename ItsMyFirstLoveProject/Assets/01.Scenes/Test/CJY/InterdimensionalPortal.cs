using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
//using UnityEngine.UI;

public class InterdimensionalPortal : MonoBehaviour
{
    //��Ż �ȿ��� ����ų� ������ ��ä�� ��Ʈ�����
    [SerializeField] private Material[]     _materials;
    [SerializeField] private GameObject     _portal;

    void Start()
    {
        Debug.Log("�÷��̾ ����");
        foreach (var mat in _materials)
        {
            mat.SetInt("_StencilComp", (int)CompareFunction.NotEqual);
            mat.SetInt("_PreStencilComp", (int)CompareFunction.NotEqual);
            mat.SetInt("_OutlineStencilComp", (int)CompareFunction.NotEqual);
        }
    }
    //�ݶ��̴��� z������ ����ؼ� ��Ż���� �Ÿ� ����
    //����ũ �������� ����ũ�� ���� ���̰ų� �Ⱥ��̰ų�
    //Equal, ��Ż �ȿ����� ������Ʈ�� ����
    //NotEqual ��Ż ����ũ �� ������Ʈ�� ����
    private void OnTriggerStay(Collider other)
    {
        if (!other.CompareTag("Player")) return;

        //��Ż�����ϴ� ������ 0.001�̶� ��Ż z�ຸ�� �ڷΰ������� d
        if (transform.position.z >= other.transform.position.z)
        {
            Debug.Log("�÷��̾ �ٱ���");
            foreach (var mat in _materials)
            {
                mat.SetInt("_StencilComp", (int)CompareFunction.NotEqual);
                mat.SetInt("_PreStencilComp", (int)CompareFunction.NotEqual);
                mat.SetInt("_OutlineStencilComp", (int)CompareFunction.NotEqual);
            }

        }
        else
        {
            Debug.Log("�÷��̾ ���԰ų� ���̰ų�");
            foreach (var mat in _materials)
            {
                mat.SetInt("_StencilComp", (int)CompareFunction.Equal);
                mat.SetInt("_PreStencilComp", (int)CompareFunction.Equal);
                mat.SetInt("_OutlineStencilComp", (int)CompareFunction.Equal);
            }
        }
    }
}
