using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestHand : MonoBehaviour
{
    [SerializeField]
    private float followSpeed = 30f;

    private Transform _followTarget;
    private Rigidbody _body;

    public Transform controller;

    public Vector3 rotationOffset;
    [SerializeField]
    private Vector3 positionOffset;

    private void Start()
    {
        //Pysics Movement
        _followTarget = controller.transform;
        _body = GetComponent<Rigidbody>();

        _body.collisionDetectionMode = CollisionDetectionMode.Continuous;
        _body.interpolation = RigidbodyInterpolation.Interpolate;

        //Teleport Hands
        _body.position = _followTarget.position;
        _body.rotation = _followTarget.rotation;
    }
    private void LateUpdate()
    {
        Vector3 positionWithOffset = controller.TransformPoint(positionOffset);
        float distance = Vector3.Distance(positionWithOffset, transform.position);
        _body.velocity = (positionWithOffset - transform.position).normalized * (followSpeed * distance);

        this.transform.rotation = controller.transform.rotation * Quaternion.Euler(rotationOffset);
    }
}
