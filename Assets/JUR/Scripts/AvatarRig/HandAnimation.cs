using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class HandAnimation : MonoBehaviour
{
    [SerializeField]
    private Animator handAnimator;

    [SerializeField]
    private InputActionReference triggerL;
    [SerializeField]
    private InputActionReference grabL;

    private void Start()
    {
        handAnimator = GetComponent<Animator>();
    }
    private void Update()
    {
        if (triggerL.action.ReadValue<float>() > 0)
        {
            handAnimator.SetFloat("TriggerL", 1f);
        }
        if (triggerL.action.ReadValue<float>() <= 0)
        {
            handAnimator.SetFloat("TriggerL", 0f);
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
