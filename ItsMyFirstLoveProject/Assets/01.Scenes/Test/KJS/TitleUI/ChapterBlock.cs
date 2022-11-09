using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChapterBlock : MonoBehaviour
{
    private GameObject _activeChapter;
    private ActiveChapterUI _actChapter;
    private GameObject _deactiveChapter;
    private DeactiveChapterUI _deactChapter;

    [SerializeField] private bool _chapterActivate;
    [SerializeField] private bool[] _heartAct = new bool[4];
    [SerializeField] private int _chapterNum;
    [SerializeField] private string _compensation;
    [SerializeField] private int _coin;
    [SerializeField] private int _stage;
    [SerializeField] private int _favorabilityLevel;



    private void Awake() 
    {
        _actChapter = GetComponentInChildren<ActiveChapterUI>();
        _activeChapter = _actChapter.gameObject;
        _deactChapter = GetComponentInChildren<DeactiveChapterUI>();
        _deactiveChapter = _deactChapter.gameObject;
    }

    private void OnEnable() 
    {
        DataSet();
        Activate(_chapterActivate);
    }

    private void DataSet()
    {
        _chapterNum = int.Parse(gameObject.name[0].ToString());
        // 저장된 데이터를 불러와서 적용해야 함.
        // 테스트시엔 임시적으로 데이터 구성해서 테스트할것.
    }

    private void Activate(bool active)
    {
        _activeChapter.SetActive(active);
        _deactiveChapter.SetActive(!active);
        
        if(active)
        {
            ActivateChapterSet();
        }
        else
        {
            DeactivateChapterSet();
        }
    }

    private void ActivateChapterSet()
    {
        for(int i = 0; i < _heartAct.Length; i++)
        {
            _actChapter.HeartSet(i, _heartAct[i]);
        }

        _actChapter.TextSet(_chapterNum, _compensation, _favorabilityLevel, _coin);
    }

    private void DeactivateChapterSet()
    {
        _deactChapter.TextSet(_chapterNum, _stage, _favorabilityLevel);
    }



}
