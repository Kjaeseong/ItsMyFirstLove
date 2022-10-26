using UnityEngine;

public class HeightCheckUI : MonoBehaviour
{
    private HeightChecker _checker;
    [SerializeField] private GameObject _okButton;

    private void Start() 
    {
        _checker = GetComponentInChildren<HeightChecker>();
    }

    private void Update() 
    {
        ActivateButton();
    }

    private void ActivateButton()
    {
        if(_checker.DetectionPlane())
        {
            _okButton.SetActive(true);
        }
        else
        {
            _okButton.SetActive(false);
        }
    }

    /// <summary>
    /// 버튼 누르면 UI비활성화 및 게임매니저 높이 관련 프로퍼티 세팅
    /// </summary>
    public void DeactivateUI()
    {
        GameManager.Instance.SetCameraHeight(_checker.GetHeight());
        gameObject.SetActive(false);
    }
}
