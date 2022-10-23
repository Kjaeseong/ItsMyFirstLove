using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    private void Update() 
    {
        MovePlayer();
        Rotation();
    }

    private void Rotation()
    {
        if(Input.GetKey(KeyCode.A))
        {
            transform.Rotate(0f, -1f, 0f);
        }
        if(Input.GetKey(KeyCode.D))
        {
            transform.Rotate(0f, 1f, 0f);
        }
    }

    private void MovePlayer()
    {
        if(Input.GetKey(KeyCode.W))
        {
            transform.Translate(0f, 0f, 0.05f);
        }
        if(Input.GetKey(KeyCode.S))
        {
            transform.Translate(0f, 0f, -0.05f);
        }
    }
}
