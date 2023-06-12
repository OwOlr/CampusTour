using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.InputSystem;

public class TestSimpleIteractable : XRBaseInteractable
{

    [SerializeField]
    private InputActionReference triggerActionReference;

    public bool preseed;
    

    protected override void OnHoverEntered(XRBaseInteractor interactor)
    {
        triggerActionReference.action.performed += ClickDebug;

        
    }
    protected override void OnSelectEntered(XRBaseInteractor interactor)
    {
        Debug.Log("Selected : " + this.name);


        preseed = true;
    }

    protected override void OnSelectEntering(XRBaseInteractor interactor)
    {
        Debug.Log("SelectEntering : " + this.name);
        this.transform.position = new Vector3(interactor.transform.position.x, 
            interactor.transform.position.y, this.transform.position.z);
        preseed = true;
    }

    protected override void OnSelectExited(XRBaseInteractor interactor)
    {
        Debug.Log("SelectExit : " + this.name);
        preseed = false;
    }

    public void ClickDebug(InputAction.CallbackContext obj)
    {
            Debug.Log("Click Button!!!");
    }
}
