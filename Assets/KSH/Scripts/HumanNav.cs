using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class HumanNav : MonoBehaviour
{
    public Transform target;
    Vector3 destination;
    NavMeshAgent agent;
    NpcState npcState;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        destination = agent.destination;
        npcState = GetComponent<NpcState>();

    }
    void Update()
    {

        if (Vector3.Distance(destination, target.position) > 4.0f)
        {
            destination = target.position;
            agent.destination = destination;
        }
    }
}
