using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseUI : MonoBehaviour
{
    [SerializeField] private GameObject _exitPopUpUI;
    private KJS_OptionUI _optionUI;

    private void OnEnable() 
    {
        _exitPopUpUI.SetActive(false);
    }

    /// <summary>
    /// 이어하기 버튼 선택. 자신 오브젝트 종료
    /// </summary>
    public void CountinueButton()
    {
        gameObject.SetActive(false);
    }

    /// <summary>
    /// 게임종료 선택시 씬에 따라 동작 선택
    /// </summary>
    public void ExitButton()
    {
        if(GameManager.Instance._scene.GetName() == "StoryMode")
        {
            _exitPopUpUI.SetActive(true);
        }
        else if(GameManager.Instance._scene.GetName() == "WalkMode")
        {
            GameManager.Instance._scene.Change("MainTitle");
        }
    }

    /// <summary>
    /// 게임종료 선택 팝업 비활성화
    /// </summary>
    public void ExitPopUpNoButton()
    {
        _exitPopUpUI.SetActive(false);
    }

    /// <summary>
    /// 게임매니저를 통해 씬체인저 호출, 씬 교체
    /// </summary>
    public void ExitPopUpYesButton()
    {
        GameManager.Instance._scene.Change("MainTitle");
    }

    /// <summary>
    /// 옵션 버튼 선택
    /// </summary>
    public void OptionButton()
    {
        _optionUI.BackMenuObjectSet(gameObject);
        _optionUI.gameObject.SetActive(true);
        gameObject.SetActive(false);
    }
}
