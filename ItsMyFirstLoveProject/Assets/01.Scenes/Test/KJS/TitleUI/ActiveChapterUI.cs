using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ActiveChapterUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _chapterNum;
    [SerializeField] private TextMeshProUGUI _compensation;
    [SerializeField] private TextMeshProUGUI _status;

    [SerializeField] private GameObject[] _alpha0 = new GameObject[4];
    [SerializeField] private GameObject[] _alpha1 = new GameObject[4];
    private GameObject _chapterSelectUI;

    private void Start() 
    {
        _chapterSelectUI = GetComponentInParent<ChapterSelectUI>().gameObject;
    }

    public void HeartSet(int index, bool active)
    {
        _alpha1[index].SetActive(active);
        _alpha0[index].SetActive(!active);
    }

    public void TextSet(int ChapterNum, string Compen,float FavorabilityLevel, int Coin)
    {
        _chapterNum.text = $"Chapter {ChapterNum}";
        _compensation.text = Compen;
        _status.text = $"호감도 : {FavorabilityLevel}, 코인 : {Coin}";
    }

    public void ActivateStageWindow()
    {
        _chapterSelectUI.SetActive(false);
        // TODO : 스테이지 정보창 구현시 아래 코드 사용.
        // _stageWindow.SetActive(true);
        // _stageWindowScript.BackMenuObjectSet(_chapterSelectUI);
    }
}
