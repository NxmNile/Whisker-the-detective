using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] float moveSpeed = 5f;
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }
    void Update()
    {
        // Handle movement
        float move = Input.GetAxis("Horizontal");
        Vector3 movement = new Vector3(move,0,0) * moveSpeed * Time.deltaTime;
        transform.Translate(movement, Space.World);

        // Flip the player model based on movement direction
        if (move > 0)
        {
            transform.rotation = Quaternion.Euler(0, 90, 0); // Facing right
        }
        else if (move < 0)
        {
            transform.rotation = Quaternion.Euler(0, -90, 0); // Facing left
        }
        animator.SetBool("IsWalk", move != 0);
    }
    
}
