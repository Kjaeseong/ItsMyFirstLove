using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private GameObject _exitUI;
    [SerializeField]
    private Text _levelText;
    [SerializeField]
    private Image _favorabilityGage;

    public float Favorability = 5f;
    public float MaxFavorability =100f;
    public int Level = 1;
    public float NowFavorability = 0f;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            _exitUI.SetActive(true);
        }
        if(_favorabilityGage.fillAmount >= 1)
        {
            LevelUP();
        }

        _levelText.text = $"Lv.{Level}";

    }

    public void AppExit()
    {
        Application.Quit();
    }

    public void LevelUP()
    {
        Level++;
        _favorabilityGage.fillAmount = 0;
        NowFavorability = 0;
    }

    public void FavorabilityUP()
    {
        NowFavorability = NowFavorability + Favorability;
        _favorabilityGage.fillAmount = NowFavorability / MaxFavorability;
        Debug.Log(NowFavorability);
    }    
}
