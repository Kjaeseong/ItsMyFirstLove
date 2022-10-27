using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class NormalUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _levelText;
    [SerializeField] private Image _gauge;
    private InGameUI _inGameUI;

    private void Start() 
    {
        _inGameUI = GetComponentInParent<InGameUI>();
    }

    public void ActivatePause()
    {
        _inGameUI.Pause();
    }

    public void GaugeSet()
    {
        _gauge.fillAmount = GameManager.Instance.LoveGauge / 100;
    }

    public void LevelTextSet()
    {
        _levelText.text = "Lv." + GameManager.Instance.Level.ToString();
    }


}
