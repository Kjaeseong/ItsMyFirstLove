using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChapterNum : MonoBehaviour
{
    //é�͸� Ŭ���ϸ� ���������Ŵ����� ����
    public StageManager[] StageManager;
    public void ReturnChapterNum(int ChapterNum)
    {
       for(int i = 0; i < StageManager.Length; i++)
        {
            StageManager[i].ChpaterNumber = ChapterNum;
        }

    }
}
