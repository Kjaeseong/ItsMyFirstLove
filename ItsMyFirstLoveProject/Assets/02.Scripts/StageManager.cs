using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StageManager : MonoBehaviour
{
    public int[] ClearReward;
    public int[] ClearTime;

    public int ChpaterNumber;

    public Text StageInfoText;

    private IEnumerator StageSet()
    {
        if (ChpaterNumber == 1)
        StageInfoText.text = $"보상 호감도: {ClearReward[0]} \n 플레이 시간: {ClearTime[0]}분";
        yield return null;
    }
}
