using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QueueTest : MonoBehaviour
{
    
    private Queue<int> que = new Queue<int>();

    private void Awake() 
    {
        for(int i = 0; i < 5; i++)
        {
            que.Enqueue(i);
        }

        
            if(que.Dequeue() == 0)
            {
                Debug.Log(que.Count);
                if(que.Dequeue() == 1)
                {
                    Debug.Log(que.Count);
                }
            }
            
        
        
    }
}
