using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RotationCheckUI : MonoBehaviour
{
    private bool _isButtonDown;
    private int _direction;
    [SerializeField] private TextMeshProUGUI _boxText;
    private InGameUI _inGameUI;

    private void Start() 
    {
        _inGameUI = GetComponentInParent<InGameUI>();
    }

    private void OnEnable() 
    {
        // TODO : Map 내 건물들 불투명 매트리얼 적용 코드 추가해야함.
    }

    private void OnDisable() 
    {
        // TODO : Map 내 건물들 투명 매트리얼 적용 코드 추가해야함
    }

    private void Update() 
    {
        RotateMap();
        BoxTextSet($"Map Rot : {GameManager.Instance.MapRotateY.ToString()}");
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

    /// <summary>
    /// Close 버튼 클릭시 동작
    /// </summary>
    public void CompleteRotationCheck()
    {
        _inGameUI.CompleteRotationCheck();
    }

    private void BoxTextSet(string Text)
    {
        _boxText.text = Text;
    }

    private void RotateMap()
    {
        if(_isButtonDown)
        {
            GameManager.Instance.AddMapRotateY(0.1f * _direction);
        }
    }
}
