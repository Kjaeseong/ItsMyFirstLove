using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    //이 매니저는 테스트를 위한 매니저 입니다.

    [SerializeField]
    private GameObject  _exitUI;

    [SerializeField]
    private Text        _levelText;

    [SerializeField]
    private Image       _favorabilityGage;

    public float    Favorability = 5f;
    public float    MaxFavorability =100f;
    public int      Level = 1;
    public float    NowFavorability = 0f;

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

        

    }
    //앱 종료
    public void AppExit()
    {
        Application.Quit();
    }
    
    //레벨 업
    public void LevelUP()
    {
        Level++;
        _levelText.text = $"Lv.{Level}";
        _favorabilityGage.fillAmount = 0;
        NowFavorability = 0;
    }

    //호감도 업
    public void FavorabilityUP()
    {
        NowFavorability = NowFavorability + Favorability;
        _favorabilityGage.fillAmount = NowFavorability / MaxFavorability;
        Debug.Log(NowFavorability);
    }    
}
