using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class HandAnimation : MonoBehaviour
{
    [SerializeField]
    private Animator handAnimator;

    [SerializeField]
    private InputActionReference triggerR;
    [SerializeField]
    private InputActionReference grabL;

    private void Start()
    {
        handAnimator = GetComponent<Animator>();
    }
    private void Update()
    {
        Debug.Log("Trigger r : " + triggerR.action.ReadValue<float>());
        if (triggerR.action.ReadValue<float>() > 0)
        {
            handAnimator.SetFloat("TriggerR", 1f);
        }
        if (triggerR.action.ReadValue<float>() <= 0)
        {
            handAnimator.SetFloat("TriggerR", 0f);
        }
        
        if (grabL.action.ReadValue<float>() > 0)
        {
            handAnimator.SetFloat("GrabL", 1f);
        }
        if (grabL.action.ReadValue<float>() <= 0)
        {
            handAnimator.SetFloat("GrabL", 0f);
        }

    }


}
