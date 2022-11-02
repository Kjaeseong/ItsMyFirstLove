using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PathFinder : MonoBehaviour
{
    private LineRenderer _lineRenderer;
    private NavMeshAgent _navMeshAgent;

    private void Start()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
        _lineRenderer = GetComponent<LineRenderer>();
        _lineRenderer.startWidth = _lineRenderer.endWidth = 4f;
        _lineRenderer.enabled = false;
    }

    private void Update()
    {
        if(_lineRenderer.enabled == false)
        {
            _lineRenderer.enabled = true;
        }

        if(_lineRenderer.enabled == true)
        {
            MakePath();
        }
    }

    // 라인을 그려주는 함수
    private void DrawPath()
    {
        int length = _navMeshAgent.path.corners.Length;
        _lineRenderer.positionCount = length;

        for (int i = 1; i < length; i++)
        {
            _lineRenderer.SetPosition(i, _navMeshAgent.path.corners[i]);
        }
    }

    // 다음 라인과 이어주는 함수
    private void MakePath()
    {
        _lineRenderer.SetPosition(0, this.transform.position);
        DrawPath();
    }
}
