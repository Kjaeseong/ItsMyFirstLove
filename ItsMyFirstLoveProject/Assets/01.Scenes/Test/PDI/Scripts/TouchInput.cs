using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class TouchInput : MonoBehaviour
{
    private Inventory _inven;

    private Items _item;

    private ARRaycastManager _raycastMgr;
    private List<ARRaycastHit> _hits = new List<ARRaycastHit>();
    private GameObject _selectObject;
    private Camera _arCamera;

    void Start()
    {
        _inven = GetComponent<Inventory>();
        _raycastMgr = GetComponent<ARRaycastManager>();
        _arCamera = Camera.main;
    }


    void Update()
    {
        //if (Input.touchCount == 0)
        //{
        //    return;
        //}

        //Touch _touch = Input.GetTouch(0);

        //if(_touch.phase == TouchPhase.Began)
        //{
        //    Ray _ray;
        //    RaycastHit _hit;

        //    _ray = _arCamera.ScreenPointToRay(_touch.position);

        //    if (Physics.Raycast(_ray, out _hit))
        //    {
        //        //모든 선물 아이템은 Collectable 태그를 가지고 있을 예정
        //        if (_hit.collider.tag == "Collectable")
        //        {
        //            _selectObject = _hit.collider.gameObject;
        //            _item = _selectObject.GetComponent<Items>();
        //            GameManager.Instance.TouchItem(_item);
        //        }
        //    }
        //}

        if(Input.GetMouseButtonDown(0))
        {
            Ray _ray = _arCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit _hit;
            Debug.Log("레이저 발사");
            if (Physics.Raycast(_ray, out _hit))
            {
                Debug.Log("뭔가 맞았다");
                if(_hit.collider.tag == "Collectable")
                {
                    Debug.Log("아이템 맞았다.");
                    _selectObject = _hit.collider.gameObject;
                    _item = _selectObject.GetComponent<Items>();
                    GameManager.Instance.TouchItem(_item);
                }
            }
        }
    }
}
