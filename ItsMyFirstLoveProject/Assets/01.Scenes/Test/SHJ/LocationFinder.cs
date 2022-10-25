using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class LocationFinder : MonoBehaviour
{
    [SerializeField] private NavMeshAgent _ai;
    [SerializeField] private GameObject[] _destinations;
    [SerializeField] private GameObject   _player;

    private int   _locationCount = 0;
    private float _elaspedTime = 0f;
    private bool  _isClose;

    private void Awake()
    {
        _ai = GetComponent<NavMeshAgent>();
        _isClose = false;
    }

    private void Start()
    {
        MoveWayPoint();
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
    }

    private void Delay()
    {
        _ai.ResetPath();
    }

    // 이동 가능하게 해준다.
    private void MoveWayPoint()
    {
        // 유효한 경로가 아닐 경우 리턴한다.
        if (_ai.isPathStale)
        {
            return;
        }
        _ai.destination = _destinations[0].transform.position;
    }

    // 캐릭터가 목적지 포인트에 도착하면 다음 목적지로 변경해준다.
    private void OnTriggerEnter(Collider other)
    {
        _isClose = true;

        if (other.tag == "Location")
        {
            Debug.Log("도착");

            if (_locationCount < 3)
            {
                _locationCount++;
                Debug.Log($"{_locationCount}");
                _ai.destination = _destinations[_locationCount].transform.position;
            }

            else if (_locationCount == 3)
            {
                _locationCount = 0;
                Debug.Log($"{_locationCount}");
                _ai.destination = _destinations[_locationCount].transform.position;
            }

            if (_destinations == null)
            {
                return;
            }
        }

    }

    // 캐릭터근처에 플레이어가 있으면 이동한다.
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            _ai.speed = 6f;
        }
    }

    // 캐릭터 근처에 플레이어가 없으면 실행.
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            _isClose = false;
            _ai.speed = 0f;
        }
    }

    // 플레이어가 경로대로 움직이지 않으면 실행.
    private void PlayerStopped(GameObject player)
    {
        Debug.Log("왜 안와?");
        transform.LookAt(player.transform.position);
    }
}
