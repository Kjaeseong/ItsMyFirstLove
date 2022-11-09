using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public int Favorability { get; private set; }
    public int Level { get; private set; }

    private void Start()
    {
        LoadCharacterData();
    }

    public void ReceivePresent(int impression)
    {
        if (impression == 1)
        {
            Favorability += 20;

            if (Favorability >= 100)
            {
                Favorability -= 100;
                ++Level;
            }
        }

        else if(impression == 2)
        {
            Favorability -= 10;
        }

        if (Favorability < 0)
        {
            Favorability = 0;
        }
    }

    public void LoadCharacterData()
    {
        Favorability = GameManager.Instance._dataMgr.Favorability;
        Level = GameManager.Instance._dataMgr.Level;
    }

    public void SaveCharacterData()
    {
        GameManager.Instance._dataMgr.SaveCharacterData(Favorability, Level);
    }
}
