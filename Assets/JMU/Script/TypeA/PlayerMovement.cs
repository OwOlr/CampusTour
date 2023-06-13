using UnityEngine;
using UnityEngine.AI;

//��ũ��Ʈ�� �߰��ϸ� �ڵ����� ������Ʈ �߰�
[RequireComponent(typeof(NavMeshAgent),typeof(Animator))]
public class PlayerMovement : MonoBehaviour {
    [SerializeField] private Camera Cam = null;
    [SerializeField] private NavMeshAgent Agent = null;
    [SerializeField] private Animator Animator = null;

    private const string Is_Walk = "Is_Walk";
    private const string Is_Sit = "Is_Sit";
    private RaycastHit[] Hits = new RaycastHit[1];

    private void Awake() {
        Agent = GetComponent<NavMeshAgent>();
        Animator = GetComponent<Animator>();
    }

    private void Update() { 
        if (Input.GetKeyUp(KeyCode.Mouse0)) {
            Ray ray = Cam.ScreenPointToRay(Input.mousePosition);
            if(Physics.RaycastNonAlloc(ray, Hits) > 0) {
                Agent.SetDestination(Hits[0].point);
            }
        }
    }
}
