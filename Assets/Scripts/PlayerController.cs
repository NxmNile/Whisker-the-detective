using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerController : MonoBehaviour
{
    [SerializeField] public float moveSpeed = 5f;
    public float initialSpeed;
    public bool IsTalking = false;
    private Animator animator;
    private Rigidbody rb;
    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        initialSpeed = moveSpeed;
    }
    
    void Update()
    {   
        if (!IsTalking) {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical= Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(moveHorizontal, 0, moveVertical) * moveSpeed * Time.deltaTime;
        
        rb.MovePosition(transform.position + movement);

        // Rotate the player model based on movement direction
        if (movement != Vector3.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(movement, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, 720 * Time.deltaTime);
        }

        // Update animator parameter
        bool isMoving = moveHorizontal != 0 || moveVertical != 0;
       
        animator.SetBool("IsWalk", isMoving);
        }

        if (IsTalking)
        {
            animator.SetBool("IsWalk",false);
        }
        
           
    }

    private void OnCollisionEnter(Collision other)
    {
        string objectName = other.gameObject.name;
        if (objectName == "Hootie"||objectName=="oven"||objectName=="desk"||objectName=="chair"||objectName=="WARDOBE")
        {
            moveSpeed = 0;
        }
    }

    private void OnCollisionStay(Collision other)
    {
        moveSpeed = initialSpeed;
    }

    private void OnCollisionExit(Collision other)
    {
        moveSpeed = initialSpeed;
    }
}
