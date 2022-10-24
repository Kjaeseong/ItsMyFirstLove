using Google.Maps.Examples;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OpenChapter : MonoBehaviour
{
    //���� ȣ���� ���� �޼� �� ���� é�� Ŭ����� ���� é�� ����

    public bool         isClear;
    public UIManager    PlayerLv;
    public int          OpenLv;

    public Text         ChapterText;
    public Text         NonOpenTextInfo;
    public Image        ChapterBack;

    private Button _chapterButton;

    private void Start()
    {
        _chapterButton = GetComponent<Button>();
    }
    private void Update()
    {
        InteractiveChpater();
    }
    
    private void InteractiveChpater()
    {
        if (isClear && PlayerLv.Level >= OpenLv)
        {
            Destroy(NonOpenTextInfo);
            ChapterText.rectTransform.localPosition = new Vector3(0, 0, 0);
            ChapterBack.color = new Color(255, 255, 0);
            _chapterButton.interactable = true;
        }
    }

}
