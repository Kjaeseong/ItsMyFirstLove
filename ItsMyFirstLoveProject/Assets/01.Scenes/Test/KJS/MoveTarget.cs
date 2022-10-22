using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTarget : MonoBehaviour
{    
    [SerializeField] private GameObject _player;
    [SerializeField] private float _checkCycle;

    private Vector3 _nowPosition;
    private Vector3 _prevPosition;


    private void Start() 
    {
        StartCoroutine(DistanceCheck());
    }




    private IEnumerator DistanceCheck()
    {
        while(true)
        {
            _prevPosition = _nowPosition;
            _nowPosition = _player.transform.position;

            Vector3 dir = _nowPosition - _prevPosition;
            float dist = Vector3.Distance(_nowPosition, _prevPosition);
            dir.y = 0f;
            Quaternion rot = Quaternion.LookRotation(dir.normalized);

            //테스트용 로그출력
            Debug.Log(rot.eulerAngles);
            yield return new WaitForSeconds(_checkCycle);
        }
    }

}
