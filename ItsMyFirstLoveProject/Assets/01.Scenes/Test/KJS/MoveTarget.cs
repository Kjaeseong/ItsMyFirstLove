using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTarget : MonoBehaviour
{    
    [SerializeField] private GameObject _player;
    [SerializeField] private float _checkCycle;

    private Vector3 _nowPosition;
    private Vector3 _prevPosition;
    private float _nowDistance;
    private float _prevDistance;


    private void Start() 
    {
        StartCoroutine(DistanceCheck());
    }

    private void PositionSet()
    {
        
    }


    private IEnumerator DistanceCheck()
    {
        while(true)
        {
            _prevPosition = _nowPosition;
            _prevDistance = _nowDistance;
            _nowPosition = _player.transform.position;

            Vector3 dir = _nowPosition - _prevPosition;
            dir.y = 0f;
            _nowDistance = dir.magnitude;
            Quaternion rot = Quaternion.LookRotation(dir.normalized);

            Debug.Log(rot.eulerAngles);

            if(_nowDistance >= 0.01)
            {
                transform.SetPositionAndRotation(_player.transform.position, rot);
            }
            else if(true)
            {

            }
            
            yield return new WaitForSeconds(_checkCycle);
        }
    }

}
