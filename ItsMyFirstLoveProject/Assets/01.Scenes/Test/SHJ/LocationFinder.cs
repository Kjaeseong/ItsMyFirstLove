using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class LocationFinder : MonoBehaviour
{
    [SerializeField] private NavMeshAgent _ai;
    [SerializeField] private GameObject _player;
    [SerializeField] private GameObject _destinationUI;

    private AnimationSupport _animationSupport;
    private int _locationCount = 0;
    private float _elaspedTime = 0f;

    public GameObject[] _destinations;

    private void Start()
    {
        _destinationUI = GameObject.Find("DestinationUI");
        _player = GameObject.Find("Player");
        MoveWayPoint();
    }

    private void OnEnable()
    {
        _ai = GetComponent<NavMeshAgent>();
        _animationSupport = GetComponentInChildren<AnimationSupport>();
    }


    private void Update()
    {
        _elaspedTime += Time.deltaTime;

        // 하나 이동을 위해서 절대값 계산
        Vector3 offset = _ai.transform.position - _player.transform.position;
        float sqrLen = offset.sqrMagnitude; // 20.3

        if (sqrLen > 0)
        {
            MoveHana();

            if (sqrLen > 20)
            {
                PlayerStopped(_player);

                //15초가 지나면 데이트 이벤트 종료.
                if (_elaspedTime > 15f)
                {
                    Debug.Log("데이트가 종료됩니다.");
                    _elaspedTime = 0f;
                }
            }
        }
    }

    private void MoveWayPoint()
    {
        // 유효한 경로가 아닐 경우 리턴한다.
        if (_ai.isPathStale)
        {
            return;
        }
        _ai.destination = _destinations[0].transform.position;
        _destinationUI.transform.position = _ai.destination;
    }

    // 캐릭터 이동 함수
    private void MoveHana()
    {
        SetGameOverToTime();
        _ai.speed = 1f;
        _animationSupport.Play("Move");
    }

    // 플레이어가 경로대로 움직이지 않으면 실행.
    private void PlayerStopped(GameObject player)
    {
        _animationSupport.Play("Idle");
        _ai.speed = 0f;
        Debug.Log("왜 안와?");
        Vector3 target = new Vector3(
            player.transform.position.x,
            transform.position.y,
            player.transform.position.z);
        transform.LookAt(target);
    }

    // 경과시간 초기화 함수
    private void SetGameOverToTime()
    {
        _elaspedTime = 0f;
    }

    // 캐릭터가 목적지 포인트에 도착하면 다음 목적지로 변경해준다.
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Location")
        {
            if (_locationCount < _destinations.Length - 1)
            {
                _destinations[_locationCount].SetActive(false);
                StartCoroutine(CollOnOff(transform.GetComponent<CapsuleCollider>()));

                _locationCount++;
                _ai.destination = _destinations[_locationCount].transform.position;
                _destinationUI.transform.position = _ai.destination;
            }

            else if (_locationCount == _destinations.Length)
            {
                Debug.Log("경로끝");
                _ai.speed = 0f;
            }

            if (_destinations == null)
            {
                return;
            }
        }
    }

    // 목적지 도착 시 콜라이더를 끄는 코루틴
    IEnumerator CollOnOff(CapsuleCollider coll)
    {
        coll.enabled = false;
        yield return new WaitForSecondsRealtime(3f);
        coll.enabled = true;
    }
}

