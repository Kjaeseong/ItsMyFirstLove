using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KJS_OptionUI : MonoBehaviour
{
    [SerializeField] private GameObject _credit;
    [SerializeField] private Slider _bgmSlider;
    [SerializeField] private Slider _seSlider;

    private AudioManager _audio;

    //private GameObject _backMenu;

    private void OnEnable() 
    {
        SliderValueSet(GameManager.Instance._audio.GetVolume());
    }
    
    private void OnDisable() 
    {
        //_backMenu.SetActive(true);
    }

    private void Update() 
    {
        GameManager.Instance._audio.SetVolume(_bgmSlider.value, _seSlider.value);
    }

    private void SliderValueSet(Vector2 volume)
    {
        _bgmSlider.value = volume.x;
        _seSlider.value = volume.y;
    }

    /// <summary>
    /// 닫기 버튼 클릭시 이전 UI로 돌아가기 위해 오브젝트 입력
    /// </summary>
    public void BackMenuObjectSet(GameObject BackMenu)
    {
        //_backMenu = BackMenu;
    }

    /// <summary>
    /// 크레딧 버튼 클릭시 크레딧 실행
    /// </summary>
    public void ActivateCredit()
    {
        _credit.SetActive(true);
    }

    /// <summary>
    /// 닫기 버튼 선택시 동작
    /// <summary>
    public void ClickBackButton()
    {
        gameObject.SetActive(false);
    }
}
