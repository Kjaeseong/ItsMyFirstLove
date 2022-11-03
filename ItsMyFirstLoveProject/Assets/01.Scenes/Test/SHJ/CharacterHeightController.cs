using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterHeightController : MonoBehaviour
{
    private Transform _parentsTransform;

    private void Start()
    {
        _parentsTransform = GetComponentInParent<Transform>();
    }

    private void Update()
    {
        Vector3 _position = new Vector3(_parentsTransform.position.x, Camera.main.transform.position.y - 1.3f, _parentsTransform.position.z);
        transform.position = _position;
    }
}
