using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FullScreenMiniMap : MonoBehaviour
{
    [SerializeField] GameObject _fullScreenMiniMap;
    public void ActiveFullScreen()
    {
        _fullScreenMiniMap.SetActive(true);
    }

    public void InActiveFullScreen()
    {
        _fullScreenMiniMap.SetActive(false);
    }
}
