using UnityEngine;
using UnityEngine.AI;


public class ScoutMovement : MonoBehaviour
{
    public NavMeshAgent navAgent;
    public Vector3 targetPosition;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        navAgent.SetDestination(targetPosition);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
