using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class LocationFinder : MonoBehaviour
{
    [SerializeField] private NavMeshAgent _ai;
    [SerializeField] private GameObject _player;
    private LineRenderer _lineRenderer;
    private AnimationSupport _animationSupport;
    private int _locationCount = 0;
    private float _elaspedTime = 0f;
    private bool _isClose;


    public GameObject[] _destinations;

    private void Start()
    {
        _player = GameObject.Find("Player");
        _isClose = false;
        MoveWayPoint();

        _lineRenderer = GetComponent<LineRenderer>();
        _lineRenderer.startWidth = _lineRenderer.endWidth = 4f;
        //_lineRenderer.material.color = Color.black;
        _lineRenderer.enabled = false;

    }

    private void OnEnable()
    {
        _ai = GetComponent<NavMeshAgent>();
        _animationSupport = GetComponentInChildren<AnimationSupport>();
    }


    private void Update()
    {
        _elaspedTime += Time.deltaTime;
        // 캐릭터근처에 플레이어가 없다면 실행된다.
        if (_isClose == false)
        {
            PlayerStopped(_player);

            // 15초가 지나면 데이트 이벤트 종료.
            if (_elaspedTime > 15f)
            {
                Debug.Log("데이트가 종료됩니다.");
                _elaspedTime = 0f;
            }
        }
        MakePath();
    }
    private void MoveWayPoint()
    {
        // 유효한 경로가 아닐 경우 리턴한다.
        if (_ai.isPathStale)
        {
            return;
        }
        _ai.destination = _destinations[0].transform.position;
    }

    //  makePathCoroutine()을 시작하는 함수
    private void MakePath()
    {
        _lineRenderer.enabled = true;
        StartCoroutine(MakePathCoroutine());
    }

    // 라인을 그려주는 함수
    private void DrawPath()
    {
        int length = _ai.path.corners.Length;
        _lineRenderer.positionCount = length;

        for (int i = 1; i < length; i++)
        {
            _lineRenderer.SetPosition(i, _ai.path.corners[i]);
        }
    }

    // 현재 위치에서 다음 목적지까지 그려주는 코루틴
    private IEnumerator MakePathCoroutine()
    {
        _lineRenderer.SetPosition(0, this.transform.position);

        yield return new WaitForSeconds(0.1f);

        DrawPath();
    }

    // 플레이어가 경로대로 움직이지 않으면 실행.
    private void PlayerStopped(GameObject player)
    {
        _animationSupport.Play("Idle");
        _ai.speed = 0f;
        Debug.Log("왜 안와?");
        transform.LookAt(player.transform.position);
    }

    // 경과시간 초기화 함수
    private void SetGameOverToTime()
    {
        _elaspedTime = 0f;
    }

    private void MoveHana()
    {
        SetGameOverToTime();
        _ai.speed = 1f;
        _animationSupport.Play("Move");
    }
    // 캐릭터가 목적지 포인트에 도착하면 다음 목적지로 변경해준다.
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Location")
        {
            Debug.Log("도착");

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
            Invoke("MoveHana", 2f);
        }

    }

    // 캐릭터근처에 플레이어가 있으면 이동한다.
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {

        }
    }

    // 캐릭터 근처에 플레이어가 없으면 실행.
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            _isClose = false;
        }
    }

}

    