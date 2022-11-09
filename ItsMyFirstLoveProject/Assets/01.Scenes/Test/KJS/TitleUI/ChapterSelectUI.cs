using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChapterSelectUI : MonoBehaviour
{
    [SerializeField] private GameObject _backMenu;


    public void BackButton()
    {
        _backMenu.SetActive(true);
        gameObject.SetActive(false);
    }

    public void BackMenuObjectSet(GameObject BackMenu)
    {
        _backMenu = BackMenu;
    }
}
