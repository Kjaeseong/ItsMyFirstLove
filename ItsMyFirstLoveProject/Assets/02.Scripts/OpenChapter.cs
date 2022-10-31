using Google.Maps.Examples;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OpenChapter : MonoBehaviour
{
    //���� ȣ���� ���� �޼� �� ���� é�� Ŭ����� ���� é�� ����

    public bool         isClear;
    //���� ��������
    public UIManager    PlayerLv;
    //é�� ���°����� ����
    public int          OpenLv;
    //��ġ�� ��ȯ�ϱ� ���� ������
    public Text         ChapterText;
    //�ؽ�Ʈ Info �����ϱ�
    public Text         NonOpenTextInfo;
    //��׶���
    public Image        ChapterBack;
    //��ư Ȱ��ȭ
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
