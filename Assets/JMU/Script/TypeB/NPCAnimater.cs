using UnityEngine;
using UnityEngine.AI;



[RequireComponent(typeof(NavMeshAgent), typeof(Animator))]
public class NPCAnimater : MonoBehaviour {
    private enum State { 
        Idle,
        Moving,
        Sitting
    }

    Animator anim = null;
    NavMeshAgent agent = null;

    private State curState;

    private Vector3 tgPos;

    private float targetRange = 10f;
    
    private void Awake() {
        anim = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
    }
    private  void Start() {
        curState = State.Idle;
        agent.updateRotation = false;
    }

    private void Update() {
        switch (curState) {
            case State.Idle:
                anim.SetBool("Is_Idle", true);
                anim.SetBool("Is_Walk", false);
                anim.SetBool("Is_Run", false);
                anim.SetBool("Is_Run", false);
                break;
            case State.Moving:
                anim.SetBool("Is_Idle", false);
                anim.SetBool("Is_Walk", true);
                anim.SetBool("Is_Run", false);
                anim.SetBool("Is_Run", false);
                break;
            case State.Sitting:
                anim.SetBool("Is_Idle", true);
                anim.SetBool("Is_Walk", false);
                anim.SetBool("Is_Run", false);
                anim.SetBool("Is_Run", false);
                break;
        }

        CheckStateTransition();
    }

    private void CheckStateTransition() { 
        if (curState == State.Idle) {
            if (IsTargetInRange()) {
                curState = State.Moving;
                tgPos = GetNewTargetPosition();
            }
        }
    }

    private void MoveToTarget() {
        //��ǥ ��ġ�� �̵��ϴ� ����
        agent.SetDestination(Vector3.MoveTowards
            (transform.position, tgPos, Time.deltaTime * agent.speed));
    }

    private bool IsTargetInRange() {
        //�Ÿ� �˻����
        float dis = Vector3.Distance(transform.position, tgPos);
        return dis < targetRange;
    }

    private Vector3 GetNewTargetPosition() {
        //�������� �����ϵ��� ����
        return new Vector3(Random.Range(-10f, 10f), 0f, Random.Range(-10f, 10f));
    }
}
