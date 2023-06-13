using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class CustomGrabInteractableUI : XRGrabInteractable
{
    //Grab �C �� ��ü�� ���� ���� ��ġ.

    public Transform uiButtonTransform;
    
    private bool isHover;

    private void Start()
    {
        
    }

    //Grab ��ư Ŭ�� �� ����Ǵ� �Լ�
    protected override void OnSelectEntered(XRBaseInteractor interactor)
    {
        if (interactor.CompareTag("Left Hand"))
        {
            //������ �� ��ġ�� �޾ƿ� ��ü�� ��ġ ��Ŵ. 
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

    //Tirgger ��ư Ŭ�� �� ����Ǵ� �Լ�
    protected override void OnActivate(XRBaseInteractor interactor)
    {
        
    }

    protected override void OnDeactivate(XRBaseInteractor interactor)
    {
       
    }
}
