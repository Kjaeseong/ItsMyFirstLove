using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class NormalUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _levelText;
    [SerializeField] private Image _gauge;
    private PauseUI _pauseUI;

    /// <summary>
    /// 일시정지 버튼 선택시
    /// </summary>
    public void PauseButton()
    {
        _pauseUI.gameObject.SetActive(true);
    }

    /// <summary>
    /// 호감도 게이지 Set
    /// </summary>
    public void GaugeSet()
    {
        _gauge.fillAmount = GameManager.Instance.LoveGauge / 100;
    }

    /// <summary>
    /// 레벨 표시 텍스트 Set
    /// </summary>
    public void LevelTextSet()
    {
        _levelText.text = "Lv." + GameManager.Instance.Level.ToString();
    }
}
