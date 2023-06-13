using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.InputSystem;

public class ScalerInteractable : XRBaseInteractable
{

    [SerializeField]
    private InputActionReference triggerActionReference;

    private XRBaseInteractor inputInteractor;

    public Transform baseObject;
    public Transform targetObject;

    public bool ishover;
    public bool isTrigger;
    
    public bool preseed;

    private void Start()
    {
        triggerActionReference.action.performed += ClickDebug;   
    }
    private void FixedUpdate()
    {
        if (ishover)
        {
            float isOnOff = triggerActionReference.action.ReadValue<float>();

            if (isOnOff > 0f)
            {
                Debug.Log("Pressed Trigger!!");
                this.transform.position = new Vector3(inputInteractor.transform.position.x,
                    inputInteractor.transform.position.y, this.transform.position.z);
                float dis = Vector3.Distance(baseObject.transform.position, targetObject.transform.position);
                Debug.Log("Distance : "+ dis);

                RectTransform rect = baseObject.GetComponent<RectTransform>();
                RectTransform btnRect = this.GetComponent<RectTransform>();

                //Right , Top
                rect.offsetMax = new Vector2(btnRect.offsetMax.x - 50, rect.offsetMax.y);
                //Left , Bottom
                rect.offsetMin = new Vector2(rect.offsetMin.x, btnRect.offsetMin.y + 50);
            }
        }
        
    }

    protected override void OnHoverEntered(XRBaseInteractor interactor)
    {
        ishover = true;
        inputInteractor = interactor;


    }
    protected override void OnHoverExited(XRBaseInteractor interactor)
    {
        ishover = false;
    }
    protected override void OnSelectEntered(XRBaseInteractor interactor)
    {
        Debug.Log("Selected : " + this.name);


        preseed = true;
    }

    protected override void OnSelectEntering(XRBaseInteractor interactor)
    {
        if (interactor.CompareTag("Left Hand"))
        {
            Debug.Log("SelectEntering : " + this.name);
            this.transform.position = new Vector3(interactor.transform.position.x,
                interactor.transform.position.y, this.transform.position.z);
        }
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
