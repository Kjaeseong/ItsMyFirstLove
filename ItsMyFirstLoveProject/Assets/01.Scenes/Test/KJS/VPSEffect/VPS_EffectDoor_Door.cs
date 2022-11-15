using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VPS_EffectDoor_Door : MonoBehaviour
{
    [SerializeField] private GameObject _door;
    [SerializeField] private float _doorSpeed;
    [SerializeField] private Animator _anim;
    private int _moveDirection;

    private void Update() 
    {
        Debug.Log(_door.transform.rotation.eulerAngles.y);

        if(DistToAR() < 5)
        {
            _anim.SetBool("Open", true);
        }
        else
        {
            _anim.SetBool("Open", false);
        }
    }

    private float DistToAR()
    {
        return Mathf.Abs(Vector3.Distance(Camera.main.transform.position, transform.position));
    }


}
