using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using TMPro;

public class WalkUI : MonoBehaviour
{
    private enum CharacterButtonState
    {
        ACT,
        DEACT,
        COUNT
    }

    [SerializeField] private TextMeshProUGUI _charButton;
    [SerializeField][Range(0, 10)] private float ActiveCoolTime;
    
    private float _coolTime;
    private InGameUI _inGameUI;

    private int _characterButtonStep;
    private int _prevButtonStep;


    private void Update() 
    {
        CharacterButtonSet();
    }

    private void Start() 
    {
        _inGameUI = GetComponentInParent<InGameUI>();
    }

    /// <summary>
    /// 버튼 클릭시 게임매니저의 케릭터 활성화 관련 bool 변수 값 전환 <br/>
    /// GameManager.Instance._isActCharacterWalkMode;
    /// </summary>
    public void ActivateCharacter()
    {
        if(_characterButtonStep != (int)CharacterButtonState.COUNT)
        {
            GameManager.Instance.ActivateCharacterInWalk();
        }
    }

    /// <summary>
    /// InGameUI의 인벤토리 활성화 함수 호출 
    /// </summary>
    public void ActivateInventory()
    {
        _inGameUI.Inventory();
    }

    public void ActivateCamera()
    {

    }

    
    private void CharacterButtonSet()
    {
        _prevButtonStep = _characterButtonStep;
        if(!GameManager.Instance._isActCharacterWalkMode)
        {
            if(_coolTime <= 0)
            {
                _characterButtonStep = (int)CharacterButtonState.ACT;
            }
            else
            {
                _coolTime -= Time.deltaTime;
                _characterButtonStep = (int)CharacterButtonState.COUNT;
                _charButton.text = $"{(int)_coolTime}s";
            }
        }
        else
        {
            _coolTime = ActiveCoolTime;
            _characterButtonStep = (int)CharacterButtonState.DEACT;
        }

        if(_prevButtonStep != _characterButtonStep)
        {
            if(!GameManager.Instance._isActCharacterWalkMode)
            {
                _charButton.text = "Char act";
            }
            else
            {
                _charButton.text = "Char DeAct";
            }
        }
        
    }

    private void CoolTimeCount()
    {
        
    }

}
