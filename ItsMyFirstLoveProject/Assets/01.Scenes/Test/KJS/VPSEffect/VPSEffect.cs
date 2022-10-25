using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VPSEffect : MonoBehaviour
{
    // 인스펙터 창에서 오브젝트풀을 통제하기 위한 변수
    // List에 등록된 프리팹이 없다면(List 크기가 0이면) 풀이 생성되지 않음
    // 1. 인스펙터상 List(1, 2, 3그룹)에 풀에 포함시킬 프리팹 추가,
    // 2. PoolSize : 해당 그룹의 프리팹을 담을 풀의 사이즈
    // 3. PosRange : 랜덤배치할 범위
    // 4. Height : 배치 높이
    // 5. 이 외 직접 배치하는 오브젝트들은 VPSEffect 프리팹에 직접 추가

    [SerializeField] private List<GameObject> _firstPrefabGroup = new List<GameObject>();
    [SerializeField] private int _firstPoolSize;
    [SerializeField][Range(0, 30)] private float _firstPosRange;
    [SerializeField][Range(0, 30)] private float _firstHeight;
    [SerializeField] private List<GameObject> _secondPrefabGroup = new List<GameObject>();
    [SerializeField] private int _secondPoolSize;
    [SerializeField][Range(0, 30)] private float _secondPosRange;
    [SerializeField][Range(0, 30)] private float _secondHeight;
    [SerializeField] private List<GameObject> _thirdPrefabGroup = new List<GameObject>();
    [SerializeField] private int _thirdPoolSize;
    [SerializeField][Range(0, 30)] private float _thirdPosRange;
    [SerializeField][Range(0, 30)] private float _thirdHeight;

    private List<GameObject> _pool = new List<GameObject>();
    private int _poolSize;
    private int _formula;
    private float _posRange;
    private float _height;

    private void Start() 
    {
        for(int i = 0; i < 3; i++)
        {
            CreatePool(i);
        }
    }

    /// <summary>
    /// index : 풀에 추가할 프리팹 그룹, 1 ~ 3중 입력.<br/>
    /// Start() 함수에서 자동 실행중임.
    /// </summary>
    private void CreatePool(int index)
    {
        PoolSettingCheck(index - 1);

        int count = 0;
        for(int i = 0; i < _poolSize; i++)
        {
            switch(index - 1)
            {
                case 0:
                    _pool.Add(Instantiate(_firstPrefabGroup[count]));
                    break;
                case 1:
                    _pool.Add(Instantiate(_secondPrefabGroup[count]));
                    break;
                case 2:
                    _pool.Add(Instantiate(_thirdPrefabGroup[count]));
                    break;
            }
            _pool[_pool.Count - 1].transform.parent = gameObject.transform;
            _pool[_pool.Count - 1].transform.position = RandPos(_posRange, _height);
            _pool[_pool.Count - 1].transform.rotation = Quaternion.Euler(
                _pool[_pool.Count - 1].transform.rotation.eulerAngles.x, 
                Random.Range(-180, 180), 
                _pool[_pool.Count - 1].transform.rotation.eulerAngles.z
            );
            count = (count + 1) % _formula;
        }
    }

    private void PoolSettingCheck(int index)
    {
        switch(index)
        {
            case 0:
                _poolSize = _firstPoolSize;
                _formula = _firstPrefabGroup.Count;
                _posRange = _firstPosRange;
                _height = _firstHeight;
                break;
            case 1:
                _poolSize = _secondPoolSize;
                _formula = _secondPrefabGroup.Count;
                _posRange = _secondPosRange;
                _height = _secondHeight;
                break;
            case 2:
                _poolSize = _thirdPoolSize;
                _formula = _thirdPrefabGroup.Count;
                _posRange = _thirdPosRange;
                _height = _thirdHeight;
                break;
        }
    }

    private Vector3 RandPos(float range, float posY)
    {
        float x = Random.Range(-1* range, range);
        float z = Random.Range(-1* range, range);
        Vector3 position = new Vector3(x, posY, z);

        return position;
    }


}
