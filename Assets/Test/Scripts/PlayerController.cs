using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private InputActionReference jumpActionReference;
    [SerializeField] private float jumpForce = 5.0f;

    private CharacterController controller;
    private Vector3 movedir;

    public float gravity;


    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();  
    }

    // Update is called once per frame
    void Update()
    {
        jumpActionReference.action.performed += OnJump;

        movedir.y -= gravity*Time.deltaTime;
        controller.Move(movedir * Time.deltaTime);
        //Debug.DrawRay(transform.position, Vector3.down * 10.0f, Color.red);
    }

    private void OnJump(InputAction.CallbackContext obj)
    {
        if (!controller.isGrounded) return; 
            Debug.Log("buttonPressed");
            movedir.y = jumpForce;
        //ScreenCapture.CaptureScreenshot("happy.png");
    }
   
}
