using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FullScreenMiniMap : MonoBehaviour
{
    [SerializeField] GameObject _fullScreenMiniMap;

    [SerializeField] Camera _miniMapCamera;

    private bool _isFullScreen;

    private float _oldTouchDistance;
    private float _cameraSize = 150f;
    private float _currentTouchDistance;
    private float _touchDistance;
    private float _zoomMaxDistance = 300f;
    private float _zoomMinDistance = 70f;

    private void Update()
    {
        ZoomInOutMiniMap();
    }

    /// <summary>
    /// 미니맵 전체화면 활성화 & 비활성화
    /// </summary>
    public void SwitchFullScreen()
    {
        _isFullScreen = !_isFullScreen;
        _fullScreenMiniMap.SetActive(_isFullScreen);
    }

    // 미니맵 두 손가락으로 줌 인 & 아웃 처리 함수
    private void ZoomInOutMiniMap()
    {
        if (!_isFullScreen)
        {
            return;
        }

        if (Input.touchCount == 2 && (Input.touches[0].phase == TouchPhase.Moved || Input.touches[1].phase == TouchPhase.Moved))
        {
            _currentTouchDistance = (Input.touches[0].position - Input.touches[1].position).sqrMagnitude;
            _touchDistance = (_currentTouchDistance - _oldTouchDistance) * 0.01f;
            _cameraSize -= _touchDistance;
            _cameraSize = Mathf.Clamp(_cameraSize, 70f, 300f);
            _miniMapCamera.orthographicSize = Mathf.Lerp(_miniMapCamera.orthographicSize, _cameraSize, Time.deltaTime * 5f);
            _oldTouchDistance = _currentTouchDistance;
        }
    }
}
