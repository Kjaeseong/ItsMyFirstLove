using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VPSEffectManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> _effectList = new List<GameObject>();
    private List<GameObject> _effectPool = new List<GameObject>();

    // TODO : 게임매니저 제작시 아래 temp변수를 게임매니저에서 맵의 기준높이로 받아와야 함.
    private float temp;

    private void Start() 
    {
        CreatePool();
    }

    public void EffectSwitch(int effectNum, Vector3 position)
    {
        _effectList[effectNum].transform.position = new Vector3(
            position.x,
            temp,
            position.z
        );

        _effectList[effectNum].SetActive(true);
    }

    public void DeactivateEffect(int effectNum)
    {
        _effectList[effectNum].SetActive(false);
    }

    private void CreatePool()
    {
        for(int i = 0; i < _effectList.Count; i++)
        {
            _effectPool[i] = Instantiate(_effectList[i]);
            
        }
    }
}
