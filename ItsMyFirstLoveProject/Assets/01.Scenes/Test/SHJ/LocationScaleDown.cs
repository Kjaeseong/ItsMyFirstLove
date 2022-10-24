using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocationScaleDown : MonoBehaviour
{
    [SerializeField] private GameObject LocationLine;

    private LocationFinder _locationFinder;
    private void Start()
    {
        _locationFinder = GetComponent<LocationFinder>();
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {

            LocationLine.transform.localScale -= new Vector3(0, 0, 0.5f);
            LocationLine.transform.localPosition += new Vector3(0, 0, 0.25f);
            if (LocationLine.transform.localScale.z == 0)
            {
                LocationLine.gameObject.SetActive(false);
            }
        }
    }
}
