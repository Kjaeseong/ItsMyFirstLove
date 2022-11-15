using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _character;
    [SerializeField] private CharacterCommunicationUI _animationSetting;
    private bool _isCharacterOn;

    private void AddCharacter()
    {
        Instantiate(_character, Camera.main.transform.position, Quaternion.identity);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("EventTrigger") && false == _isCharacterOn)
        {
            _isCharacterOn = true;
            AddCharacter();
        }
    }
}
