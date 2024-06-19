using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class npcController : MonoBehaviour
{   
    [SerializeField] private float startIdleTime;
    [SerializeField] private PlayerController playerController;
    [SerializeField] private float rotationSpeed = 5f;
    [SerializeField] private Interrogation interrogation;
    public Transform targetTransform;
    private Vector3 targetPoint;
    private Animator animator;
    private Quaternion initialRotation;
    void Start()
    {
        animator = GetComponent<Animator>();
        Invoke("StartIdle",startIdleTime);
        initialRotation = transform.rotation;
    }

    void Update()
    {
        if (playerController.IsTalking&&interrogation.objectName==this.gameObject.name)
        {
            // Check if a target transform is assigned
            if (targetTransform != null)
            {
                targetPoint = targetTransform.position;
            }
            // Calculate the direction to the target point
            Vector3 direction = (targetPoint - transform.position).normalized;

            // Calculate the rotation step
            Quaternion targetRotation = Quaternion.LookRotation(direction);

            // Rotate the character smoothly
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);

            // Calculate the amount of rotation needed and log it
            float rotationDegree = GetRotationDegree(direction);
            //Debug.Log("Rotation degree needed: " + rotationDegree);
        }
        else
        {
            // Rotate the character back to the initial rotation smoothly
            transform.rotation = Quaternion.Slerp(transform.rotation, initialRotation, rotationSpeed * Time.deltaTime);
        }
        
    }
    private float GetRotationDegree(Vector3 direction)
    {
        // Calculate the angle between the character's forward direction and the direction to the target
        float angle = Vector3.Angle(transform.forward, direction);

        // Determine the cross product to check if the angle is to the left or right
        Vector3 cross = Vector3.Cross(transform.forward, direction);
        if (cross.y < 0)
        {
            angle = -angle;
        }

        return angle;
    }
    private void StartIdle()
    {
        animator.SetBool("IsIdle", true);
    }
}
