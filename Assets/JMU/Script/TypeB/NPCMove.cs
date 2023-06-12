using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent), (typeof(Animator)))]
public class NPCMove : MonoBehaviour
{
    private NavMeshAgent nMA = null;
    private Animator anim = null;


    [SerializeField] private Transform[] tPos = null;

    private int curPos = 0;

    private void Awake()
    {
        nMA = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
    }
    private void Start()
    {
        nMA.autoBraking = false;
        nMA.updateRotation = false;
        anim.SetBool("Is_Walk", true);
        NextWPPos();
    }

    private void Update()
    {
        MoveOnNPC();
        //MoveOnNPC안에 넣으면 if문 돌때만 회전해서 따로 뺌.
        RotationNPC();
    }

    private void MoveOnNPC()
    {
        if (!nMA.pathPending && nMA.remainingDistance < .2f)
        {
            anim.SetBool("Is_Walk", true);
            NextWPPos();
        }
        if (curPos == tPos.Length)
        {
            curPos = 0;
        }
    }
    private void NextWPPos()
    {
        nMA.destination = tPos[curPos].position;
        curPos = (curPos + 1);
    }

    private void RotationNPC()
    {
        if (nMA.velocity.sqrMagnitude >= .1f * .1f && nMA.remainingDistance <= .1f)
        {
            anim.SetBool("Is_Walk", false);
        }
        else if (nMA.desiredVelocity.sqrMagnitude >= .1f * .1f)
        {

            //앞의 장애물을 회피하는것까지 고려한 속도
            Vector3 dir = nMA.desiredVelocity;
            //회전각도 계산
            Quaternion tAngle = Quaternion.LookRotation(dir);
            //선형보간 함수를 사용해서 부드러운 회전.
            transform.rotation =
                Quaternion.Slerp(transform.rotation, tAngle, Time.deltaTime * 8f);
        }
    }
}