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
    public void RotateTowardsCamera()
    {
        // Find the main camera
        //Camera mainCamera = Camera.main;

        // Ensure the main camera exists
        if (mainCamera != null)
        {
            // Calculate the direction from the character to the camera
            Vector3 directionToCamera = mainCamera.transform.position - transform.position;

            // Ignore the y component to only rotate on the y-axis
            directionToCamera.y = 0;

            // If the direction vector is non-zero
            if (directionToCamera.sqrMagnitude > 0.001f)
            {
                // Calculate the rotation needed to look at the camera
                Quaternion targetRotation = Quaternion.LookRotation(directionToCamera);

                // Apply the rotation instantly on the y-axis only
                transform.rotation = Quaternion.Euler(0, targetRotation.eulerAngles.y, 0);
            }
        }
    }
}
