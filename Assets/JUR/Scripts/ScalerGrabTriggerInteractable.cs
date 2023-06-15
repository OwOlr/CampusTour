using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.InputSystem;

public class ScalerGrabTriggerInteractable : XRBaseInteractable
{
    private XRBaseInteractor inputInteractor;


    public Transform baseObject;
    public Transform targetObject;

    public bool isSelect;

    [SerializeField]
    private InputActionReference triggerActionReference;


    private void FixedUpdate()
    {

        if (isSelect)
        {
            OnScaleChange();
        }
  
    }

    protected override void OnSelectEntering(XRBaseInteractor interactor)
    {
        inputInteractor = interactor;
        isSelect = true;
    }

    protected override void OnSelectExited(XRBaseInteractor interactor)
    {
        isSelect = false;
    }

    private void OnScaleChange()
    {
        RectTransform rect = baseObject.GetComponent<RectTransform>();
        RectTransform btnRect = this.GetComponent<RectTransform>();

        this.transform.position = new Vector3(inputInteractor.transform.position.x,
            inputInteractor.transform.position.y, this.transform.position.z);

        //Right , Top
        rect.offsetMax = new Vector2(btnRect.offsetMax.x - 50, rect.offsetMax.y);
        //Left , Bottom
        rect.offsetMin = new Vector2(rect.offsetMin.x, btnRect.offsetMin.y + 50);
    }


}
