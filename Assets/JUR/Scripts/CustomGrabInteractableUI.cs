using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class CustomGrabInteractableUI : XRGrabInteractable
{
    //Grab 핧 때 물체가 붙을 기준 위치.

    public Transform uiButtonTransform;
    
    private bool isHover;

    private void Start()
    {
        
    }

    //Grab 버튼 클릭 시 실행되는 함수
    protected override void OnSelectEntered(XRBaseInteractor interactor)
    {
        if (interactor.CompareTag("Left Hand"))
        {
            //기준이 될 위치를 받아와 물체를 위치 시킴. 
            this.transform.position = new Vector3(interactor.transform.position.x,
            interactor.transform.position.y, this.transform.position.z);



        }
        if (interactor.CompareTag("Right Hand"))
        {
            this.attachTransform = uiButtonTransform;
        }
    }

    protected override void OnSelectExited(XRBaseInteractor interactor)
    {
        
    }

    //Tirgger 버튼 클릭 시 실행되는 함수
    protected override void OnActivate(XRBaseInteractor interactor)
    {
        
    }

    protected override void OnDeactivate(XRBaseInteractor interactor)
    {
       
    }
}
