using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NpcState : MonoBehaviour
{
    enum State
    {
        ZERO,
        Idle = 0,
        Walk,
        Event,
        COUNT
    }

    private State state;
    Animator animator;
    bool isWalk;
    bool isEvent;
    float curTime;
    float ranNum;

    public Transform target;
    Vector3 destination;
    NavMeshAgent agent;
    NpcState npcState;

    List<Transform> moveRouteTargets = new List<Transform>();

    private void Awake()
    {
        animator = GetComponent<Animator>();

        agent = GetComponent<NavMeshAgent>();
        destination = agent.destination;
        npcState = GetComponent<NpcState>();
    }

    private void Start()
    {
        state = State.Idle;
        isWalk = false;
        isEvent = false;
    }

    private void Update()
    {
        if (state.Equals(State.Walk) && Vector3.Distance(destination, target.position) > 1.0f)
        {
            destination = target.position;
            agent.destination = destination;
        }
        
        if(state.Equals(State.Idle) || state.Equals(State.Event)) 
        {
            agent.destination = transform.position;
        }

        if (animator != null) 
        {
            ChangeState();
        }
    }

    private void ChangeState()
    {    

        curTime += Time.deltaTime;
        
        if (curTime > 5f)
        {
            ranNum = Random.Range((int)State.ZERO, (int)State.COUNT);
            curTime = 0;
        }

        state = (State)ranNum;

        switch (state)
        {
            case State.Idle:
                isWalk = false;
                isEvent = false;
                animator.SetBool("Idle", true);
                animator.SetBool("Walk", isWalk);
                animator.SetBool("Event", isEvent);
                break;
            case State.Walk:
                isWalk = true;
                isEvent = false;
                animator.SetBool("Idle", false);
                animator.SetBool("Walk", isWalk);
                animator.SetBool("Event", isEvent);
                break;
            case State.Event:
                isWalk = false;
                isEvent = true;
                animator.SetBool("Idle", false);
                animator.SetBool("Walk", isWalk);
                animator.SetBool("Event", isEvent);
                break;
            default: break;
        }
    }

}
