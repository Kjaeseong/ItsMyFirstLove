using UnityEngine;
using UnityEngine.AI;
using System.Collections;
using System.Collections.Generic;
using NavMeshBuilder = UnityEngine.AI.NavMeshBuilder;

[DefaultExecutionOrder(-102)]
public class LocalNavMeshBuilder : MonoBehaviour
{
    [SerializeField] private Transform _meshTracked;
    [SerializeField] private Vector3 _meshSize = new Vector3(200.0f, 200.0f, 200.0f);

    private NavMeshData _meshOfNavMesh;
    private AsyncOperation _meshOfOperation;
    private NavMeshDataInstance _meshOfInstance;
    private List<NavMeshBuildSource> _meshOfSources = new List<NavMeshBuildSource>();

    private IEnumerator Start()
    {
        while (true)
        {
            UpdateNavMesh(true);
            yield return _meshOfOperation;
        }
    }
    private void OnEnable()
    {
        _meshOfNavMesh = new NavMeshData();
        _meshOfInstance = NavMesh.AddNavMeshData(_meshOfNavMesh);

        if (_meshTracked == null)
        {
            _meshTracked = transform;
        }

        UpdateNavMesh(false);
    }
    private void OnDisable()
    {
        _meshOfInstance.Remove();
    }

    // �׺�޽� ������ �ǽð����� ������Ʈ�Ѵ�.
    private void UpdateNavMesh(bool asyncUpdate = false)
    {
        NavMeshSourceTag.Collect(ref _meshOfSources);
        var defaultBuildSettings = NavMesh.GetSettingsByID(0);
        var bounds = QuantizedBounds();

        if (asyncUpdate)
        {
            _meshOfOperation = NavMeshBuilder.UpdateNavMeshDataAsync(_meshOfNavMesh, defaultBuildSettings, _meshOfSources, bounds);
        }

        else
        {
            NavMeshBuilder.UpdateNavMeshData(_meshOfNavMesh, defaultBuildSettings, _meshOfSources, bounds);
        }
    }

    // �׺�޽��� Bake �� ���� ����
    private static Vector3 Quantize(Vector3 vector, Vector3 quant)
    {
        float x = quant.x * Mathf.Floor(vector.x / quant.x);
        float y = quant.y * Mathf.Floor(vector.y / quant.y);
        float z = quant.z * Mathf.Floor(vector.z / quant.z);

        return new Vector3(x, y, z);
    }

    // ���ο� ������Ʈ�� ������ Tag �� ����ִ� ���� Bake
    private Bounds QuantizedBounds()
    {
        var center = _meshTracked ? _meshTracked.position : transform.position;
        return new Bounds(Quantize(center, 0.1f * _meshSize), _meshSize);
    }

    // ������Ʈ�� �����(��)�� �������ش�.
    private void OnDrawGizmosSelected()
    {
        if (_meshOfNavMesh)
        {
            Gizmos.color = Color.green;
            Gizmos.DrawWireCube(_meshOfNavMesh.sourceBounds.center, _meshOfNavMesh.sourceBounds.size);
        }

        Gizmos.color = Color.yellow;
        var bounds = QuantizedBounds();
        Gizmos.DrawWireCube(bounds.center, bounds.size);

        Gizmos.color = Color.green;
        var center = _meshTracked ? _meshTracked.position : transform.position;
        Gizmos.DrawWireCube(center, _meshSize);
    }
}
