using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Capture : MonoBehaviour
{
    ActionBasedController controller;

    private void Start()
    {
        controller.GetComponent<ActionBasedController>();
        
    }
    private void Update()
    {
        float var = controller.selectAction.action.ReadValue<float>();
        Debug.Log(var);
    }

    private void OnMouseDown()
    {
        ScreenCapture.CaptureScreenshot("screenShoot1.png");
    }
}
