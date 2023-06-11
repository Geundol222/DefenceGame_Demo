using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMover : MonoBehaviour
{
    [SerializeField] EnemyController mainTower;
    [SerializeField] LayerMask endPointLayer;

    private NavMeshAgent agent;
    private Transform endPoint;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    private void Start()
    {
        endPoint = GameObject.FindGameObjectWithTag("EndPoint").transform;
        agent.destination = endPoint.position;
    }
}
