using UnityEngine;
using TMPro;

public class HeightCheckUI : MonoBehaviour
{
    private HeightCheck _checker;
    [SerializeField] private GameObject _okButton;
    [SerializeField] private TextMeshProUGUI _boxText;
    private InGameUI _inGameUI;

    private void Start() 
    {
        _checker = GetComponentInChildren<HeightCheck>();
        _inGameUI = GetComponentInParent<InGameUI>();
    }

    private void Update() 
    {
        _okButton.SetActive(_checker.DetectionPlane());
        BoxTextSet($"Cam height : {_checker.GetHeight() + 0.4f.ToString()}");
    }

    private void BoxTextSet(string Text)
    {
        _boxText.text = Text;
    }

    private void OnDisable()
    {
        GameManager.Instance.SetCameraHeight(_checker.GetHeight());
    }

    /// <summary>
    /// OK버튼 선택시 동작
    /// </summary>
    public void CompleteHeightCheck()
    {
        _inGameUI.CompleteHeightCheck();
    }
}
