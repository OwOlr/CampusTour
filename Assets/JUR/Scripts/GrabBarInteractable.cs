using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;


public class GrabBarInteractable : XRBaseInteractable
{


    public Transform CnavasObject;
    public bool isSelect;

    private XRBaseInteractor baseInteractor;

    


    private void Start()
    {
       
    }
    private void FixedUpdate()
    {
        if (isSelect)
        {
            Debug.Log("SelectEntering : " + this.name);
            CnavasObject.transform.position = new Vector3(baseInteractor.transform.position.x,
                baseInteractor.transform.position.y + 0.55f, this.transform.position.z);
        }
        
    }


    protected override void OnSelectEntering(XRBaseInteractor interactor)
    {
        isSelect = true;
        baseInteractor = interactor;

    }

    protected override void OnSelectExited(XRBaseInteractor interactor)
    {
        isSelect = false;

    }

}
