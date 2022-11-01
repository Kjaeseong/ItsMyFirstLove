using UnityEngine;

public class PauseUI : MonoBehaviour
{
    private InGameUI _inGameUI;

    private void Start()
    {
        _inGameUI = GetComponentInParent<InGameUI>();
    }

    /// <summary>
    /// 옵션창 호출을 위한 함수 <br/>
    /// 호출시 일시정지 오브젝트를 넘겨주면 뒤로가기 버튼 구현이 쉬워진다.
    /// </summary>
    public void ActivateOptionUI(GameObject UI)
    {
        _inGameUI.Option(gameObject);
        gameObject.SetActive(false);
        // _optionUI.SetActive(true);
        // _option.GetObject(gameObject);
        // TODO : 위와 같은 방식으로 해당 오브젝트를 넘겨줘야 
        // '뒤로가기' 등에 유동적으로 대응할 수 있음
        // 추후 옵션창 구현시 참고.
    }

    /// <summary>
    /// 게임매니저를 통해 씬체인저 호출, 씬 교체
    /// </summary>
    public void DateExit()
    {
        GameManager.Instance._scene.Change("MainTitle");
    }
}
