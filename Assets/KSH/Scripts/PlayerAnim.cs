using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnim : MonoBehaviour
{
    enum Motion
    {
        Idle,
        Walk,
        Dance
    }

    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (animator != null) 
        {
            if(Input.GetKey(KeyCode.Space)) 
            {
                animator.SetTrigger("Dance");
            }

        }
    }
}
