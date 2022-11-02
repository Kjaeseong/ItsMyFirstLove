using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterHeightController : MonoBehaviour
{
    private void Update()
    {
        Vector3 _position = new Vector3(transform.position.x, Camera.main.transform.position.y - 1.3f, transform.position.z);
        transform.position = _position;
    }
}
