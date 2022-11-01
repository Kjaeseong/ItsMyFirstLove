using UnityEngine;
using TMPro;

public class WalkUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _charButton;
    private InGameUI _inGameUI;

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
        GameManager.Instance.ActivateCharacterInWalk();
        CharacterButtonTextSet();
    }

    /// <summary>
    /// InGameUI의 인벤토리 활성화 함수 호출 
    /// </summary>
    public void ActivateInventory()
    {
        _inGameUI.Inventory();
    }

    private void CharacterButtonTextSet()
    {
        if(GameManager.Instance._isActCharacterWalkMode)
        {
            _charButton.text = "Char DeAct";
        }
        else
        {
            _charButton.text = "Char act";
        }
    }

}
