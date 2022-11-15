using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetHanaAnimation : MonoBehaviour
{
    [SerializeField] private AnimationSupport _animation;
    [SerializeField] private CharacterCommunicationUI _ui;

    private void OnEnable()
    {
        _animation = GetComponentInChildren<AnimationSupport>();
        _ui = GameObject.FindObjectOfType<CharacterCommunicationUI>();
        _ui.SetAnimetionScript(_animation);
    }
}
