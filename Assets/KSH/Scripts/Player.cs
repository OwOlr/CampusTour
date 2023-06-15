using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;

public class Player : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float turnSpeed;
    private Vector3 moveDirection;

    private void Start()
    {
        speed = 4f;
        turnSpeed = 100f;
    }

    private void Update()
    {
        PlayerMove();
        PlayerRotate();
    }

    private void PlayerMove()
    {
        Vector3 moving = transform.forward * Input.GetAxis("Vertical") + transform.right * Input.GetAxis("Horizontal");
        transform.position += moving * speed * Time.deltaTime;
    }

    private void PlayerRotate()
    {
        if(Input.GetKey(KeyCode.Q))
        {
            transform.Rotate(new Vector3(0, -turnSpeed * Time.deltaTime, 0));

        }

        if (Input.GetKey(KeyCode.E))
        {   
            transform.Rotate(new Vector3(0, turnSpeed * Time.deltaTime, 0));
        }
    }


}
