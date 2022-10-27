using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindBuildingOfBusinessName : MonoBehaviour
{
    [SerializeField] private GameObject[] BusinessNameObject;

    public string[] BusinessName;
    private void Start()
    {

    }

    /// <summary>
    /// 빌딩의 이름을 찾고, 그 위치에 상호명을 넣는 스크립트
    /// </summary>
    public void FindBusinessName()
    {
        GameObject[] BusinessNames = new GameObject[BusinessName.Length];
        Vector3[] BusinessLocation = new Vector3[BusinessName.Length];

        for (int i = 0; i < BusinessName.Length; ++i)
        {
            BusinessNames[i] = GameObject.Find(BusinessName[i]);
            BusinessLocation[i] = BusinessNames[i].transform.position;

            if (i < 4)
            {
                BusinessNameObject[0].transform.position = new Vector3(BusinessLocation[0].x + 23, BusinessLocation[0].y, BusinessLocation[0].z - 5);
                BusinessNameObject[1].transform.position = new Vector3(BusinessLocation[1].x + 11.8f, BusinessLocation[1].y, BusinessLocation[1].z - 5);
                BusinessNameObject[2].transform.position = new Vector3(BusinessLocation[2].x + 5.7f, BusinessLocation[2].y, BusinessLocation[2].z - 3.4f);
                BusinessNameObject[3].transform.position = new Vector3(BusinessLocation[3].x + 7, BusinessLocation[3].y, BusinessLocation[3].z - 3.8f);
            }

            else
            {
                BusinessNameObject[i].transform.position = BusinessLocation[i];
            }

        }
    }
}
