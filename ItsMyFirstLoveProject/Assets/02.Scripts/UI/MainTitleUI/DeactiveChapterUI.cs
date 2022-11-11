using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DeactiveChapterUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _chapterNum;
    [SerializeField] private TextMeshProUGUI _stage;
    [SerializeField] private TextMeshProUGUI _favorability;


    public void TextSet(int ChapterNum, int stage, int FavorabilityLevel)
    {
        _chapterNum.text = $"Chapter {ChapterNum}";
        _stage.text = $"Chapter {stage} 클리어";
        _favorability.text = $"호감도 Lv.{FavorabilityLevel} 달성";
    }
}
