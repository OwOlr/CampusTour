using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class NPCMovement : MonoBehaviour {
    private WPParent wpParent = null;

    private NavMeshAgent agent = null;

    private int curPos = 0;

    private void Awake() { agent = GetComponent<NavMeshAgent>(); }
    private void Start() {
        agent.autoBraking = false;
        agent.updateRotation = false;
    }

    private void Update() {
        ChackMove();
    }

    public void SetWPParent(WPParent _wpParent) {
        wpParent = _wpParent;
        
        //agent.destination = wpParent.GetWaypointTr(0).position;
    }
    private void ChackMove() {
        if (!agent.pathPending && agent.remainingDistance <=agent.stoppingDistance) {
            agent.destination = wpParent.GetWaypointTr(curPos++).position;
        }
        NPCRotation();
    }
    private void NPCRotation() {
        Vector3 dir = agent.desiredVelocity;
        Quaternion Angle = Quaternion.LookRotation(dir);
        transform.rotation = 
            Quaternion.Slerp(transform.rotation, Angle, Time.deltaTime * 8f);
    }
}
