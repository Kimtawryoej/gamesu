using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Devil : MonoBehaviour
{
    public enum CurrentState {idle, trace, attack, dead};
    public CurrentState curState = CurrentState.idle;


    private Transform _transform;
    private Transform playerTransfomr;
    private NavMeshAgent nvAgent;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
