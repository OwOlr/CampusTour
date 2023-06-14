using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Head : MonoBehaviour
{
    [SerializeField]
    private Transform rootObject;
    [SerializeField]
    private Transform followObject;

    [SerializeField]
    private Vector3 positionOffset;
    [SerializeField]
    private Vector3 rotationOffset;
    [SerializeField]
    private Vector3 _headBodsyOffset;

    private void LateUpdate()
    {
        //카메라를 따라 몸 회전
        rootObject.position = transform.position + _headBodsyOffset;
        rootObject.forward = Vector3.ProjectOnPlane(followObject.up, Vector3.up).normalized;
        
        transform.position = followObject.TransformPoint(positionOffset);
        transform.rotation = followObject.rotation * Quaternion.Euler(rotationOffset);
    }

}
