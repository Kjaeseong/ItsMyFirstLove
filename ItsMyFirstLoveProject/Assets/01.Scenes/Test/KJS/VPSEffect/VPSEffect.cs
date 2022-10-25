using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VPSEffect : MonoBehaviour
{
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

    private void CreatePool(int index)
    {
        PoolSettingCheck(index);

        int count = 0;
        for(int i = 0; i < _poolSize; i++)
        {
            switch(index)
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
