using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectionUI : MonoBehaviour
{
    [SerializeField] private GameObject[] _dirUI = new GameObject[2];

    private enum Direction
    {
        LEFT,
        RIGHT
    }

    [SerializeField] private GameObject _target;

    private void FixedUpdate() 
    {
        DirectionSet();
    }

    private float GetAngleToTarget()
    {
        Vector3 dir = _target.transform.position - Camera.main.gameObject.transform.position;
        dir.y = 0f;

        Quaternion rot = Quaternion.LookRotation(dir).normalized;

        float Angle = Mathf.Abs(rot.eulerAngles.y - Camera.main.transform.rotation.eulerAngles.y);

        return Angle;
    }

    private void DirectionSet()
    {
        int direction = 0;
        float angle = GetAngleToTarget();

        if(180 < angle && angle < 340)
        {
            _dirUI[(int)Direction.RIGHT].SetActive(true);
            _dirUI[(int)Direction.LEFT].SetActive(false);
        }
        else if(20 < angle && angle < 180)
        {
            _dirUI[(int)Direction.RIGHT].SetActive(false);
            _dirUI[(int)Direction.LEFT].SetActive(true);
        }
        else
        {
            _dirUI[(int)Direction.RIGHT].SetActive(false);
            _dirUI[(int)Direction.LEFT].SetActive(false);
        }

    }
}
