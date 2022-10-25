using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class LocationFinder : MonoBehaviour
{
    [SerializeField] private NavMeshAgent _ai;
    [SerializeField] private GameObject _player;
    private LineRenderer _lineRenderer;

    public GameObject[] _destinations;

    private int _locationCount = 0;
    private float _elaspedTime = 0f;
    private bool _isClose;

    private void Awake()
    {
        _ai = GetComponent<NavMeshAgent>();
    }

    private void Start()
    {
        _player = GameObject.Find("Player");
        _isClose = false;
        MoveWayPoint();

        _lineRenderer = this.GetComponent<LineRenderer>();
        _lineRenderer.startWidth = _lineRenderer.endWidth = 4f;
        _lineRenderer.material.color = Color.black;
        _lineRenderer.enabled = false;

    }

    private void Update()
    {
        _elaspedTime += Time.deltaTime;
        // ĳ���ͱ�ó�� �÷��̾ ���ٸ� ����ȴ�.
        if (_isClose == false)
        {
            PlayerStopped(_player);
            // 15�ʰ� ������ ����Ʈ �̺�Ʈ ����.
            if (_elaspedTime > 15f)
            {
                Debug.Log("����Ʈ�� ����˴ϴ�.");
                _elaspedTime = 0f;
            }
        }
        MakePath();
    }

    // �̵� �����ϰ� ���ش�.
    private void MoveWayPoint()
    {
        // ��ȿ�� ��ΰ� �ƴ� ��� �����Ѵ�.
        if (_ai.isPathStale)
        {
            return;
        }
        _ai.destination = _destinations[0].transform.position;
    }

    //  makePathCoroutine()�� �����ϴ� �Լ�
    private void MakePath()
    {
        _lineRenderer.enabled = true;
        StartCoroutine(MakePathCoroutine());
    }

    // ������ �׷��ִ� �Լ�
    private void DrawPath()
    {
        int length = _ai.path.corners.Length;
        _lineRenderer.positionCount = length;

        for (int i = 1; i < length; i++)
        {
            _lineRenderer.SetPosition(i, _ai.path.corners[i]);
        }
    }

    // ���� ��ġ���� ���� ���������� �׷��ִ� �ڷ�ƾ
    private IEnumerator MakePathCoroutine()
    {
        _lineRenderer.SetPosition(0, this.transform.position);

        yield return new WaitForSeconds(0.1f);

        DrawPath();
    }

    // �÷��̾ ��δ�� �������� ������ ����.
    private void PlayerStopped(GameObject player)
    {
        _ai.speed = 0f;
        Debug.Log("�� �ȿ�?");
        transform.LookAt(player.transform.position);
    }

    // ĳ���Ͱ� ������ ����Ʈ�� �����ϸ� ���� �������� �������ش�.
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Location")
        {
            Debug.Log("����");

            if (_locationCount < 3)
            {
                _locationCount++;
                _ai.destination = _destinations[_locationCount].transform.position;
            }

            else if (_locationCount == 3)
            {
                _locationCount = 0;
                _ai.destination = _destinations[_locationCount].transform.position;
            }

            if (_destinations == null)
            {
                return;
            }
        }

        if (other.tag == "Player")
        {
            _isClose = true;
        }

    }

    // ĳ���ͱ�ó�� �÷��̾ ������ �̵��Ѵ�.
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            _ai.speed = 6f;
        }
    }

    // ĳ���� ��ó�� �÷��̾ ������ ����.
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            _isClose = false;
        }
    }

}

    