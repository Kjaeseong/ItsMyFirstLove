using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationCheckUI : MonoBehaviour
{
    private bool _isButtonDown;
    private int _direction;
    private GameObject _map;

    private void Start() 
    {
        //_map = GameManager.Instance.Map;
    }

    private void OnEnable() 
    {
        // TODO : 구글맵 활성화시킬 목적, 다른 코드나 방법을 사용중이라면 해당 코드는 삭제해도 무방함.
        // _map.SetActive(true);
    }

    private void Update() 
    {
        RotateMap();
    }

    /// <summary>
    /// 버튼에 손 대고 있을 때 <br/>
    /// direction : 회전 방향, -1 혹은 1 입력
    /// </summary>
    public void ButtonDown(int direction)
    {
        _isButtonDown = true;
        _direction = direction;
    }

    /// <summary>
    /// 버튼에서 손 뗄 때
    /// </summary>
    public void ButtonUp()
    {
        _isButtonDown = false;
        _direction = 0;
    }

    private void RotateMap()
    {
        if(_isButtonDown)
        {
            GameManager.Instance.AddMapRotateY(0.1f * _direction);
        }
    }
}
