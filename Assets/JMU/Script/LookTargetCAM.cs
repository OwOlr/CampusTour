using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookTargetCAM : MonoBehaviour  {
    private Transform tr;

    [SerializeField] private Transform tg = null;

    [SerializeField,Range(0.1f,20f)] private float dis = default(float);
    [SerializeField, Range(0.1f, 10f)] private float height = default(float);
    [SerializeField,Range(0.1f,10f)] private float smoothRot = default(float);

    private void Awake()    {
        tr = GetComponent<Transform>();
    }

    private void Update()   {
        LookingTarget();
    }

    private void LookingTarget()    {
        //�ε巯�� ȸ���� ���� Mathf.LerpAngle
        float angle = Mathf.LerpAngle(tr.eulerAngles.y, tg.eulerAngles.y,
            smoothRot * Time.deltaTime);

        // euler => Quaternion ����
        Quaternion rot = Quaternion.Euler(0, angle, 0);

        // ī�޶� ��ġ�� Ÿ�� ȸ������ŭ ȸ�� �� 
        tr.position = tg.position - (rot * Vector3.forward * dis) + (Vector3.up * height);

        //Target ���� �����ϱ�
        tr.LookAt(tg);
    }
}
