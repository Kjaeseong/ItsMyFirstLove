using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class InterdimensionalPortal : MonoBehaviour
{
    //포탈 안에서 생기거나 없어짐 객채의 머트리얼들
    [SerializeField] private Material[]     _materials;

    void Start()
    {
        Debug.Log("플레이어가 들어옴");
        foreach (var mat in _materials)
        {
            ObjectMaskSetNotEqual();
        }
    }
    /// <summary>
    ///콜라이더를 z축으로 길게해서 포탈과의 거리 인지
    ///마스크 기준으로 마스크를 통해 보이거나 안보이거나
    ///Equal, 포탈 외 바깥에서 오브젝트가 보임
    ///NotEqual 포탈 안에서만  오브젝트가 보임
    /// </summary>
    private void OnTriggerStay(Collider other)
    {
        if (!other.CompareTag("Player")) return;

        //포탈입장하는 곳부터 0.001이라도 포탈 z축보다 뒤로가있으면 d
        if (transform.position.z >= other.transform.position.z)
        {
            Debug.Log("플레이어가 입구앞");
            ObjectMaskSetNotEqual();
        }
        else
        {
            Debug.Log("플레이어가 들어왔음");
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
