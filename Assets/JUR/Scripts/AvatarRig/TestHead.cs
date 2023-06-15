using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestHead : MonoBehaviour
{
    public Transform controller;

    public Vector3 positionOffset;
    public Vector3 rotationOffset;
    private void LateUpdate()
    {
        this.transform.position = controller.transform.position + positionOffset;
        this.transform.rotation = controller.transform.rotation * Quaternion.Euler(rotationOffset);
    }
}
