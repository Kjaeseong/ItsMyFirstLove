using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _character;
    public void AddCharacter()
    {
        Instantiate(_character, new Vector3(-2f, 1.5f, -2f) + Camera.main.transform.position, Quaternion.identity);
    }
}
