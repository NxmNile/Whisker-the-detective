using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateToTarget : MonoBehaviour
{
    public Transform[] targetTransform;
    private Vector3 targetPoint;
    [SerializeField] private PlayerController playerController;
    [SerializeField] private float rotationSpeed = 5f;
    [SerializeField] private Interrogation interrogation;
    [SerializeField] private GameObject mainCamera;
    public bool IsWining = false;
    void Update()
    {
        if (playerController.IsTalking)
        {
            // Check if a target transform is assigned
            if (targetTransform != null)
            {
                targetPoint = targetTransform[interrogation.index].position;
            }
            // Calculate the direction to the target point
            Vector3 direction = (targetPoint - transform.position).normalized;

            // Calculate the rotation step
            Quaternion targetRotation = Quaternion.LookRotation(direction);

            // Rotate the character smoothly
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }

        
    }
    
}
