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
        StageInfoText.text = $"���� ȣ����: {ClearReward[0]} \n �÷��� �ð�: {ClearTime[0]}��";
        yield return null;
    }
}
