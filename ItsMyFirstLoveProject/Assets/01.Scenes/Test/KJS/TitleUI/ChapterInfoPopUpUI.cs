using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChapterInfoPopUpUI : MonoBehaviour
{
    [SerializeField] private float _deactivateTime = 5f;


    private void OnEnable() 
    {
        StartCoroutine(Deactive());
    }

    private IEnumerator Deactive()
    {
        yield return new WaitForSeconds(_deactivateTime);

        gameObject.SetActive(false);
    }
}
