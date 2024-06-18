using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteriaCamera : MonoBehaviour
{
    [SerializeField] Transform target;
    public Vector3 offset;

    void Update()
    {
        Vector3 newPosition = target.position + offset;
        newPosition.x = transform.position.z; // Keep the camera's original Z position
        transform.position = newPosition;
    }
}
