using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class LocationFinder : MonoBehaviour
{
    [SerializeField]
    private NavMeshAgent AI;

    [SerializeField]
    private GameObject[] Destinations;

    private int TestNum;
    private int count = 0;

    private void Awake()
    {
        AI = GetComponent<NavMeshAgent>();
    }

    private void Start()
    {
        MoveWayPoint();

        //Invoke("Delay", 3f);
    }

    private void Delay()
    {
        AI.ResetPath();
    }

    private void MoveWayPoint()
    {
        if (AI.isPathStale)
        {
            return;
        }
        AI.destination = Destinations[0].transform.position;

    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("µµÂø");
        if (other.tag == "Location")
        {
            if (count < 3)
            {
                count++;
                Debug.Log($"{count}");
                AI.destination = Destinations[count].transform.position;
            }
            else if (count >= 3)
            {
                count = 0;
                Debug.Log($"{count}");
                AI.destination = Destinations[count].transform.position;
            }

            if (Destinations == null)
            {
                return;
            }
        }


    }
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "MainLocation")
        {
            Destinations[count].gameObject.transform.localScale = new Vector3(1, 1);
        }

        if(other.tag == "Player")
        {
            AI.speed = 5f;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
        {
            AI.speed = 0f;
        }
    }
}
