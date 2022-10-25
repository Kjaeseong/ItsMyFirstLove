using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VPSEffectManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> _effectList = new List<GameObject>();
    private List<GameObject> _effectPool = new List<GameObject>();

    private void Start() 
    {
        CreatePool();
    }

    /// <summary>
    /// effectNum : 인스펙터에서 배열로 넣어 놓은 이펙트 순번, 0부터 시작함 <br/>
    /// position : 이펙트 중심 위치
    /// </summary>
    public void ActivatedEffect(int effectNum, Vector3 position)
    {
        if(effectNum < _effectPool.Count)
        {
            _effectPool[effectNum].transform.position = new Vector3(
                position.x,

                // TODO : 추후 카메라와 지면 높이차 받아와야 함.
                position.y,
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
            _effectPool[_effectPool.Count - 1].SetActive(false);
        }
    }

    //테스트 호출용 함수. 삭제 가능
    public void Test(int a)
    {
        Vector3 position = new Vector3(
            Camera.main.transform.position.x,
            Camera.main.transform.position.y - 1.2f,
            Camera.main.transform.position.z
        );
        ActivatedEffect(a, position);
    }
}
