using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapMatchUI : MonoBehaviour
{
    [SerializeField] private Sprite _sprite;
    [SerializeField] private Image _image;

    private void OnEnable()
    {
        _image.sprite = _sprite;
    }

    /// <summary>
    /// 시작버튼 선택시 동작
    /// </summary>
    public void StartButton()
    {
        // TODO : 맵 회전 로직, 스테이지 시작을 위한 로직 추가요망.
        gameObject.SetActive(false);
    }
}
