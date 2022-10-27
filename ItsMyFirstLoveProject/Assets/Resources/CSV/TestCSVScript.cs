using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestCSVScript : MonoBehaviour
{
    private void Start()
    {
        //string str = GameManager.Instance._csv.GetCSV("testCSV", 1, "talk").ToString();
        //Debug.Log(GameManager.Instance._csv.GetCSV("testCSV", 1, "talk").ToString());
    }

    private void Update()
    {
        Debug.Log(GameManager.Instance._csv.GetCSV("ProtoLine", 3, "Talk").ToString());
    }
}
