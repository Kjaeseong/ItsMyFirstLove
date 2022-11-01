using UnityEngine;
using TMPro;

public class HeightCheckUI : MonoBehaviour
{
    private HeightCheck _checker;
    [SerializeField] private GameObject _okButton;
    [SerializeField] private TextMeshProUGUI _boxText;

    private void Start() 
    {
        _checker = GetComponentInChildren<HeightCheck>();
    }

    private void Update() 
    {
        ActivateButton();
        BoxTextSet($"Cam height : {_checker.GetHeight() + 0.4f.ToString()}");
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

    private void BoxTextSet(string Text)
    {
        _boxText.text = Text;
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
