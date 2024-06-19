using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class npcController : MonoBehaviour
{   
    [SerializeField] private float startIdleTime;
    private Animator animator;
    void Start()
    {
        animator = GetComponent<Animator>();
        Invoke("StartIdle",startIdleTime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void StartIdle()
    {
        animator.SetBool("IsIdle", true);
    }
}
