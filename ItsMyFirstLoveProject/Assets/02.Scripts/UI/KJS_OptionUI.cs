using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KJS_OptionUI : MonoBehaviour
{
    [SerializeField] private GameObject _credit;
    [SerializeField] private Slider _bgmSlider;
    [SerializeField] private Slider _seSlider;

    private GameObject _backMenu;

    private bool _hadVolume;
    private bool _hadBackMenu;
    
    //private CreditUI _creditUI;

    private void OnEnable() 
    {
        _hadVolume = false;
    }

    private void Update() 
    {
        if(!_hadVolume)
        {
            SliderValueSet(GameManager.Instance._audio.GetVolume());
            _hadVolume = true;
        }

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
        _backMenu = BackMenu;
        _hadBackMenu = true;
    }

    /// <summary>
    /// 크레딧 버튼 클릭시 크레딧 실행
    /// </summary>
    public void ActivateCredit()
    {
        // TODO : 추후 크레딧 넣을 시 여기에서 자신 오브젝트 입력해줄 것.
        _credit.SetActive(true);
    }

    /// <summary>
    /// 닫기 버튼 선택시 동작
    /// <summary>
    public void ClickBackButton()
    {
        _backMenu.SetActive(true);
        _backMenu = null;
        _hadBackMenu = false;
        gameObject.SetActive(false);
    }
}
