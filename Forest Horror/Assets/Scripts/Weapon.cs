using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Weapon : MonoBehaviour
{
    [SerializeField] Camera FPCamera;
    [SerializeField] float range = 2.5f;
    [SerializeField] float damage = 30f;
    Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();    
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            animator.SetBool("swing", true);
            Attack();
            
        }
    }

    private void Attack()
    {
        ProcessRaycast();
    }


    private void ProcessRaycast()
    {
        RaycastHit hit;
        if (Physics.Raycast(FPCamera.transform.position, FPCamera.transform.forward, out hit, range))
        {
            Debug.Log("You attacked");
            // TO DO: add audio effect AND animation for hitting the enemy
            EnemyHealth target = hit.transform.GetComponent<EnemyHealth>();
            // call a method on EnemyHealth script for reducing enemy health
            if (target == null) return;
            target.TakeDamage(30);
        }
        else
        {
            return;
            // just do the animation if you don't hit something. NO sound effect for impact.
        }
    }
}
