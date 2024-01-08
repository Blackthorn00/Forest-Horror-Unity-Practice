using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] float hitPoints = 100.0f;
    [SerializeField] ParticleSystem bloodVFX;

    // public method that reduces hit points by the amount of damage
    public void TakeDamage(float damage)
    {
        PlayBloodVFX();
        hitPoints -= damage;
        if (hitPoints <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void PlayBloodVFX()
    {
        bloodVFX.Play();
    }
}
