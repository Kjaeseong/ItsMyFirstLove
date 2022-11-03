using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class InterdimensionalPortal : MonoBehaviour
{
    [SerializeField] private Material[]     _materials;
    [SerializeField] private Text           _testText;
    [SerializeField] private string         _tagName;


    void Start()
    {
        foreach(var mat in _materials)
        {
            mat.SetInt("_StencilTest", (int)CompareFunction.Equal);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (!other.CompareTag(_tagName)) return;

        if (transform.position.z > other.transform.position.z)
        {
            Debug.Log("플레이어가 들어옴");
            _testText.text = "플레이어가 입장";
            foreach (var mat in _materials)
            {
                mat.SetInt("_StencilTest", (int)CompareFunction.Equal);
            }

        }
        else
        {
            _testText.text = "플레이어가 즐기는중";
            foreach (var mat in _materials)
            {
                mat.SetInt("_StencilTest", (int)CompareFunction.NotEqual);
            }
        }
    }

    private void OnDestroy()
    {
        foreach (var mat in _materials)
        {
            mat.SetInt("_StencilTest", (int)CompareFunction.NotEqual);
        }
    }
}
