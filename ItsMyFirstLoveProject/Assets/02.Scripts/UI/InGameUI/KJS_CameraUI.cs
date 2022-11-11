using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KJS_CameraUI : MonoBehaviour
{
    private bool _isRearCam;
    [SerializeField] private GameObject _rearCamera;
    [SerializeField] private GameObject _frontCamera;

    private GameObject _backMenu;
    [SerializeField] private GameObject _motionButton;
    [SerializeField] private GameObject _motionListPopUp;


    private void OnEnable() 
    {
        _isRearCam = true;
        SetActiveObject(_isRearCam);
        _motionListPopUp.SetActive(false);
    }


    /// <summary>
    /// UI종료시 이전 화면을 다시 출력하기 위한 변수를 설정(GameObject)
    /// BackMenu : 카메라 실행시 실행하는 객체가 자신을 담아서 호출한다.
    /// </summary>
    public void BackMenuObjectSet(GameObject BackMenu)
    {
        _backMenu = BackMenu;
    }

    /// <summary>
    /// 모션 리스트 팝업 출력
    /// </summary>
    public void ActivateMotionList()
    {
        _motionListPopUp.SetActive(true);
    }

    /// <summary>
    /// 캐릭터 애니메이션(포즈) 호출 로직
    /// </summary>
    public void ActivateCharacterAnimation(int Anim)
    {
        // TODO : 캐릭터 애니메이션 호출 로직 추가해야 함.
        _motionListPopUp.SetActive(false);
    }

    /// <summary>
    /// 카메라 촬영버튼 클릭시 동작
    /// </summary>
    public void CameraShot()
    {
        //카메라 촬영(캡쳐) 동작
    }

    /// <summary>
    /// 취소버튼 클릭시 동작
    /// </summary>
    public void CancelButton()
    {
        _backMenu.SetActive(true);
        gameObject.SetActive(false);
    }

    /// <summary>
    /// 카메라 전환버튼 클릭시 동작
    /// </summary>
    public void CameraChange()
    {
        if(_isRearCam)
        {
            _isRearCam = false;
        }
        else
        {
            _isRearCam = true;
        }

        SetActiveObject(_isRearCam);
        _motionListPopUp.SetActive(false);
    }

    private void SetActiveObject(bool Select)
    {
        _rearCamera.SetActive(Select);
        _frontCamera.SetActive(!Select);
        _motionButton.SetActive(Select);
    }
}
