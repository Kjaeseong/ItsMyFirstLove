using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class LocationFinder : MonoBehaviour
{
    [SerializeField] private NavMeshAgent _ai;
    [SerializeField] private GameObject[] _destinations;
    [SerializeField] private GameObject   _player;

    private int _locationCount = 0;
    private float _elaspedTime = 0f;
    private bool _isClose = true;

    private void Awake()
    {
        _ai = GetComponent<NavMeshAgent>();
    }

    private void Start()
    {
        MoveWayPoint();
    }
    private void Update()
    {
        _elaspedTime += Time.deltaTime;

        if (_isClose == false)
        {
            PlayerStopped(_player);

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

    private void MoveWayPoint()
    {
        if (_ai.isPathStale)
        {
            return;
        }
        _ai.destination = _destinations[0].transform.position;
    }

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
    private void OnTriggerStay(Collider other)
    {

        if (other.tag == "MainLocation")
        {
            _destinations[_locationCount].gameObject.transform.localScale = new Vector3(1, 1);
        }

        if (other.tag == "Player")
        {
            _ai.speed = 6f;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            _isClose = false;
            _ai.speed = 0f;
        }
    }

    private void PlayerStopped(GameObject player)
    {
        Debug.Log("왜 안와?");
        transform.LookAt(player.transform.position);
    }
}
