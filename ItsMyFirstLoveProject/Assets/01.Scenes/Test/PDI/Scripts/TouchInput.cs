using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class TouchInput : MonoBehaviour
{
    private Inventory _inven;

    [SerializeField] GameObject _item1;
    [SerializeField] GameObject _item2;

    private Items _item;

    private ARRaycastManager _raycastMgr;
    private List<ARRaycastHit> _hits = new List<ARRaycastHit>();
    private GameObject _selectObject;

    [SerializeField] Camera _arCamera;

    void Start()
    {
        _inven = GetComponent<Inventory>();
        _raycastMgr = GetComponent<ARRaycastManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount == 0)
        {
            return;
        }

        Touch _touch = Input.GetTouch(0);

        if(_touch.phase == TouchPhase.Began)
        {
            Ray _ray;
            RaycastHit _hit;

            _ray = _arCamera.ScreenPointToRay(_touch.position);

            if (Physics.Raycast(_ray, out _hit))
            {
                if (_hit.collider.tag == "Collectable")
                {
                    _selectObject = _hit.collider.gameObject;
                    _item = _selectObject.GetComponent<Items>();
                    _inven.AddItem(_item);
                    _hit.collider.gameObject.SetActive(false); 
                }
            }
        }
    }
}
