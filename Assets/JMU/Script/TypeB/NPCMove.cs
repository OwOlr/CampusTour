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
        //MoveOnNPC�ȿ� ������ if�� ������ ȸ���ؼ� ���� ��.
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

            //���� ��ֹ��� ȸ���ϴ°ͱ��� ����� �ӵ�
            Vector3 dir = nMA.desiredVelocity;
            //ȸ������ ���
            Quaternion tAngle = Quaternion.LookRotation(dir);
            //�������� �Լ��� ����ؼ� �ε巯�� ȸ��.
            transform.rotation =
                Quaternion.Slerp(transform.rotation, tAngle, Time.deltaTime * 8f);
        }
    }
}