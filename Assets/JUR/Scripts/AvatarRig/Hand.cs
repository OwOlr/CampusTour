using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hand : MonoBehaviour
{
    [SerializeField]
    private GameObject followObject;
    [SerializeField]
    private float followSpeed = 30f;
    [SerializeField]
    private float rotateSpeed = 100f;
    [SerializeField]
    private Vector3 positionOffset;
    [SerializeField]
    private Vector3 rotationOffset;

    private Transform _followTarget;
    private Rigidbody _body;

    private void Start()
    {
        //Pysics Movement
        _followTarget = followObject.transform;
        _body = GetComponent<Rigidbody>();

        _body.collisionDetectionMode = CollisionDetectionMode.Continuous;
        _body.interpolation = RigidbodyInterpolation.Interpolate;

        //Teleport Hands
        _body.position = _followTarget.position;
        _body.rotation = _followTarget.rotation;
    }

    private void Update()
    {
        PysicsMove();
    }

    private void PysicsMove()
    {
        //Position
        Vector3 positionWithOffset = _followTarget.TransformPoint(positionOffset);
        float distance = Vector3.Distance(positionWithOffset, transform.position);
        _body.velocity = (positionWithOffset - transform.position).normalized * (followSpeed * distance);

        //Rotation
        Quaternion rotationWithOffset = _followTarget.rotation * Quaternion.Euler(rotationOffset);
        Quaternion q = rotationWithOffset * Quaternion.Inverse(_body.rotation);
        q.ToAngleAxis(out float angle, out Vector3 axis);
        _body.angularVelocity = axis * (angle * Mathf.Deg2Rad * rotateSpeed);

    }
}
