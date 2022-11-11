using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameExitUI : MonoBehaviour
{
    private GameObject _backMenu;
    private bool _isObjectSet;

    private void OnEnable() 
    {
        _isObjectSet = false;
    }

    private void OnDisable() 
    {
        if(_isObjectSet) 
        {
            _backMenu.SetActive(true);
        }
    }

    /// <summary>
    /// 계속하기 버튼 선택시 돌아갈 UI를 활성화시키기 위함
    /// </summary>
    public void BackMenuObjectSet(GameObject BackMenu)
    {
        _backMenu = BackMenu;
        _isObjectSet = true;
    }

    /// <summary>
    /// 계속하기 버튼 선택 시 동작
    /// </summary>
    public void Countinue()
    {
        // 게임 오브젝트 비활성화
        gameObject.SetActive(false);
    }

    /// <summary>
    /// 종료 버튼 선택시 동작
    /// </summary>
    public void ExitGame()
    {
        // 어플리케이션 종료
        Application.Quit();
    }
}
