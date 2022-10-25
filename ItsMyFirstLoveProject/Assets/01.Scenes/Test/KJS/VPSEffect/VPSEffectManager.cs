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

        // TODO : 게임매니저 제작시 사라질 코드
        temp = 0f;
    }

    /// <summary>
    /// effectNum : 인스펙터에서 배열로 넣어 놓은 이펙트 순번, 0부터 시작함 <br/>
    /// position : 이펙트 중심 위치
    /// </summary>
    public void EffectSwitch(int effectNum, Vector3 position)
    {
        if(effectNum < _effectPool.Count)
        {
            _effectPool[effectNum].transform.position = new Vector3(
                position.x,
                // TODO : 게임매니저 제작시 아래 temp는 맵 기준높이 받아와야 함.
                temp,
                position.z
            );
            _effectPool[effectNum].SetActive(true);
        }
        else
        {
            Debug.Log("List Index Missing");
        }
    }

    /// <summary>
    /// effectNum : 인스펙터에서 배열로 넣어 놓은 이펙트 순번, 0부터 시작함
    /// </summary>
    public void DeactivateEffect(int effectNum)
    {
        if(effectNum < _effectPool.Count)
        {
            _effectPool[effectNum].SetActive(false);
        }
        else
        {
            Debug.Log("List Index Missing");
        }
    }

    private void CreatePool()
    {
        for(int i = 0; i < _effectList.Count; i++)
        {
            _effectPool.Add(Instantiate(_effectList[i]));
        }
    }
}
