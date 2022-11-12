using UnityEngine;

public class PauseUI : MonoBehaviour
{
    public WalkInGameUIManager WalkMainUI {
        get => WalkMainUI;
        set => WalkMainUI = value;
    }

    // public StoryInGameUIManager StoryMainUI {
    //     get => StoryMainUI;
    //     set => StoryMainUI = value;
    // }

    /// <summary>
    /// 옵션창 호출을 위한 함수 <br/>
    /// </summary>
    public void ActivateOptionUI()
    {
        if(WalkMainUI != null)
        {
            WalkMainUI.ActivateOptionUI(gameObject);
            gameObject.SetActive(false);
        }
        // if(StoryModeUI != null)
        // {
        //     StoryModeUI.ActivateOptionUI(gameObject);
        //     gameObject.SetActive(false);
        // }
    }

    /// <summary>
    /// 게임매니저를 통해 씬체인저 호출, 씬 교체
    /// </summary>
    public void DateExit()
    {
        GameManager.Instance._scene.Change("MainTitle");
    }
}
