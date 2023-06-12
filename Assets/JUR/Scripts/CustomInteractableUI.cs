using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class CustomInteractableUI : XRGrabInteractable 
{
    //Grab 핧 때 물체가 붙을 기준 위치.
    public Transform left_grab_transform;
    public Transform right_grab_transform;
    public Transform scaleUpCube;


    //Grab 버튼 클릭 시 실행되는 함수
    protected override void OnSelectEntered(XRBaseInteractor interactor)
    {
        if (interactor.CompareTag("Left Hand"))
        {
            Debug.Log("SelectEnter (L) : "+this.name);
        }
        if (interactor.CompareTag("Right Hand"))
        {
            Debug.Log("SelectEnter (R) : " + this.name);
        }
    }

    protected override void OnSelectExited(XRBaseInteractor interactor)
    {
        if (interactor.CompareTag("Left Hand"))
        {
            Debug.Log("SelectExit (L) : " + this.name);
        }
        if (interactor.CompareTag("Right Hand"))
        {
            Debug.Log("SelectExit (R) : " + this.name);
        }
    }

    protected override void OnActivate(XRBaseInteractor interactor)
    {
        if (interactor.CompareTag("Left Hand"))
        {
            Debug.Log("Activate (L) : " + this.name);
        }
        if (interactor.CompareTag("Right Hand"))
        {
            Debug.Log("Activate (R) : " + this.name);
        }
    }

}
