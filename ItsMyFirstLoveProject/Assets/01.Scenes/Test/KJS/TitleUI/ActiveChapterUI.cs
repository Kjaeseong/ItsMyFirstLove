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

    public void HeartSet(int index, bool active)
    {
        _alpha1[index].SetActive(active);
        _alpha0[index].SetActive(!active);
    }

    public void TextSet(int ChapterNum, string Compen,float Favorability, int Coin)
    {
        _chapterNum.text = $"Chapter {ChapterNum}";
        _compensation.text = Compen;
        _status.text = $"호감도 : {Favorability}, 코인 : {Coin}";
    }

    public void ActivateStageWindow()
    {

    }
}
