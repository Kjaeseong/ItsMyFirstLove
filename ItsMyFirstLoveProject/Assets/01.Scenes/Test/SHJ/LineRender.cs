using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineRender : MonoBehaviour
{
    [SerializeField] private Vector3 _ai;
    private LineRenderer _lineRenderer;

    private void Start()
    {
        _lineRenderer = GetComponent<LineRenderer>();
        _lineRenderer.startWidth = 1f;
        _lineRenderer.endWidth = 1f;

        _ai = GetComponent<Transform>().position;
    }

    private void Update()
    {
        makeLine();
    }

    private void makeLine()
    {
        _lineRenderer.SetPosition(0, _ai);
    }
}