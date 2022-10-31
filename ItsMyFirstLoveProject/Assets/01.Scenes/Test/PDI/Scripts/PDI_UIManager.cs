using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PDI_UIManager : MonoBehaviour
{
    private TextMeshProUGUI _favorText;
    private TextMeshProUGUI _levelText;

    private void Awake()
    {
        _favorText = transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>();
        _levelText = transform.GetChild(1).gameObject.GetComponent<TextMeshProUGUI>();
    }

    public void ChangeFavorability(int favor)
    {
        _favorText.text = $"Favorability : {favor}";
    }

    public void ChangeLevel(int level)
    {
        _levelText.text = $"Level : {level}";
    }
}
