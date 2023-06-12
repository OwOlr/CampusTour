using System.Collections;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class NPCMovement : MonoBehaviour {
    [SerializeField] private Transform Target;
    [SerializeField] private float UpdateSpeed = 0.1f;

    private NavMeshAgent Agent;

    private void Awake() {
        Agent = GetComponent<NavMeshAgent>();
    }

    private void Start() {
        StartCoroutine(FollowTarget());
    }

    private IEnumerator FollowTarget() {
        WaitForSeconds Wait = new WaitForSeconds(UpdateSpeed);

        while (enabled) {
            Agent.SetDestination(Target.transform.position);
            yield return Wait;
        }
    }
}
