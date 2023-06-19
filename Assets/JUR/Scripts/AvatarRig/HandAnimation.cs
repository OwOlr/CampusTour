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

    [SerializeField]
    private InputActionReference triggerR;
    [SerializeField]
    private InputActionReference grabR;

    private void Start()
    {
        handAnimator = GetComponent<Animator>();
    }
    private void Update()
    {

        //Left 애니메이션
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

        //Right 애니메이션
        if (triggerR.action.ReadValue<float>() > 0)
        {
            handAnimator.SetFloat("TriggerR", 1f);
        }
        if (triggerR.action.ReadValue<float>() <= 0)
        {
            handAnimator.SetFloat("TriggerR", 0f);
        }

        if (grabR.action.ReadValue<float>() > 0)
        {
            handAnimator.SetFloat("GrabR", 1f);
        }
        if (grabR.action.ReadValue<float>() <= 0)
        {
            handAnimator.SetFloat("GrabR", 0f);
        }
    }


}
