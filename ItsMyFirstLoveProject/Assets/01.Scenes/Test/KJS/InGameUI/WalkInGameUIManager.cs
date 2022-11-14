using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkInGameUIManager : MonoBehaviour
{
    private WalkUI _walkUI;
    private KJS_OptionUI _optionUI;
    private KJS_CameraUI _cameraUI;
    private Inventory _inventory;
    private PauseUI _pauseUI;

    private void Start() 
    {
        _walkUI = GetComponentInChildren<WalkUI>();
        _optionUI = GetComponentInChildren<KJS_OptionUI>();
        _cameraUI = GetComponentInChildren<KJS_CameraUI>();
        _inventory = GetComponentInChildren<Inventory>();
        _pauseUI = GetComponentInChildren<PauseUI>();

        _optionUI.gameObject.SetActive(false);
        _cameraUI.gameObject.SetActive(false);
        //_inventory.gameObject.SetActive(false);
        _pauseUI.gameObject.SetActive(false);
    }

    /// <summary>
    /// 일시정지 메뉴 활성화 <br/>
    /// 일시정지 메뉴 내 계속하기 버튼 클릭시 이전메뉴 호출 및 활성화
    /// </summary>
    public void ActivatePauseUI(GameObject BackMenu)
    {
        _pauseUI.gameObject.SetActive(true);
        //_pauseUI.BackMenuObjectSet(BackMenu);
        BackMenu.SetActive(false);
    }

    /// <summary>
    /// 옵션 UI활성화<br/>
    /// 옵션UI 내 Back 버튼 클릭시 이전메뉴 호출 및 활성화
    /// </summary>
    public void ActivateOptionUI(GameObject BackMenu)
    {
        _optionUI.BackMenuObjectSet(BackMenu);
        BackMenu.SetActive(false);
        _optionUI.gameObject.SetActive(true);
    }

    /// <summary>
    /// 산책UI 하단 기본메뉴 활성화
    /// </summary>
    public void ActivateWalkUI()
    {
        _walkUI.gameObject.SetActive(true);
    }

    /// <summary>
    /// 인벤토리 UI 활성화<br/>
    /// 인벤토리 UI 내 취소버튼 클릭시 이전 메뉴 호출 및 활성화
    /// </summary>
    public void ActivateInventory(GameObject BackMenu)
    {
        //_inventory.BackMenuObjectSet(BackMenu);
        _inventory.gameObject.SetActive(true);
        BackMenu.SetActive(false);
    }

    /// <summary>
    /// 카메라 UI 활성화<br/>
    /// 카메라 UI내 취소버튼 클릭시 이전 메뉴 호출 및 활성화
    /// </summary>
    public void ActivateCameraUI()
    {
        _cameraUI.BackMenuObjectSet(_walkUI.gameObject);
        _cameraUI.gameObject.SetActive(true);
        _walkUI.gameObject.SetActive(false);
    }
}
