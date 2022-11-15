using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BusMoveController : MonoBehaviour
{
    [SerializeField] private GameObject[] _busLocation;
    private float _speed = 5f;

    private void Awake()
    {
        StartCoroutine(BusRotate());
        StartCoroutine(BusMove());
    }


    IEnumerator BusRotate()
    {
        yield return new WaitForSeconds(10.5f);
        while (true)
        {
            Debug.Log("코루틴 실행중");
            transform.LookAt(_busLocation[1].transform);

            yield return new WaitForSeconds(0.01f);

            Vector3 offset = _busLocation[0].transform.position - transform.position;
            float sqrLen = offset.sqrMagnitude;

            if (sqrLen < 20f)
            {
                break;
            }
        }
    }
    IEnumerator BusMove()
    {
        while (true)
        {
            Vector3 offset = _busLocation[1].transform.position - transform.position;
            float sqrLen = offset.sqrMagnitude;

            transform.position += transform.TransformDirection(Vector3.forward * Time.deltaTime * _speed);
            yield return new WaitForSeconds(0.005f);

            if (sqrLen < 15f)
            {
                break;
            }
        }
    }
}
