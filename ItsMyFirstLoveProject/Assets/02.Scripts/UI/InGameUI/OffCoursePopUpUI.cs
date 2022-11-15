using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class OffCoursePopUpUI : MonoBehaviour
{
    private enum Step
    {
        WARNING,
        EXIT
    }

    private TextMeshProUGUI _text;

    [SerializeField] private string[] _messageForWarningStep = new string[2];

    [SerializeField] private float _delay = 15f;
    private int _warningStep;
    private float[] _delayTime = new float[2];

    private bool _timeOver;

    private void OnEnable() 
    {
        _warningStep = 0;
        for(int i = 0; i < _messageForWarningStep.Length; i++)
        {
            _delayTime[i] = _delay;
        }
    }

    private void Start() 
    {
        _text = GetComponentInChildren<TextMeshProUGUI>();
    }

    private void Update() 
    {
        if(_delayTime[(int)Step.WARNING] <= 0)
        {
            _warningStep = (int)Step.EXIT;
        }
        else
        {
            _warningStep = (int)Step.WARNING;
        }

        _delayTime[_warningStep] -= Time.deltaTime;
        TextSet(_messageForWarningStep[_warningStep]);
    }

    private void TextSet(string Message)
    {
        _text.text = Message;
    }

}
