using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocationScaleDown : MonoBehaviour
{
    [SerializeField] private GameObject _locationLine;

    private LocationFinder _locationFinder;
    private void Start()
    {
        _locationFinder = GetComponent<LocationFinder>();
    }

    // 이동경로가 줄어드는 트리거. 더 나은 사항 있으면 변경 부탁.
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {

            _locationLine.transform.localScale -= new Vector3(0, 0, 0.5f);
            _locationLine.transform.localPosition += new Vector3(0, 0, 0.25f);
            if (_locationLine.transform.localScale.z == 0)
            {
                _locationLine.gameObject.SetActive(false);
            }
        }
    }
}
