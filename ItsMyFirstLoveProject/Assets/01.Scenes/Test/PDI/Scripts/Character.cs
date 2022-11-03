using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public int Favorability { get; private set; }
    public int Level { get; private set; }

    private string _favor;
    private string _hate;


    private void Start()
    {
        Favorability = 0;
        Level = 1;

        _favor = "Item1";
        _hate = "Item2";
    }

    public void ReceivePresent(string _name)
    {
        if (_name == _favor)
        {
            Favorability += 20;

            if (Favorability >= 100)
            {
                Favorability -= 100;
                ++Level;
            }
        }

        else if(_name == _hate)
        {
            Favorability -= 10;
        }

        if (Favorability < 0)
        {
            Favorability = 0;
        }
    }
    //TODO: CSV파일형식으로 변경해야함
}
