using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class CustomGrabInteractable : XRGrabInteractable
{
    //Grab �C �� ��ü�� ���� ���� ��ġ.
    public Transform left_grab_transform;
    public Transform right_grab_transform;
    public Transform scaleUpCube;

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
            this.attachTransform = left_grab_transform;
            scaleUpCube.localScale = new Vector3(2, 3, 0.05f);
        }
        if (interactor.CompareTag("Right Hand"))
        {
            this.attachTransform = right_grab_transform;
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
