using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private GameObject impactEffect;
    [SerializeField] private float damageAmount; //to enemy
    private Rigidbody _rigidbody;
    private bool hasDamaged;

    private void Awake()
    {
        _rigidbody = GetComponentInChildren<Rigidbody>();
    }

    void Start()
    {
        _rigidbody.velocity = transform.forward * moveSpeed;
        AudioManager.instance.PlaySFX(2);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy" && !hasDamaged)
        {
            other.GetComponent<EnemyHealthController>().TakeDamage(damageAmount);
            hasDamaged = true;
        }
        Instantiate(impactEffect, transform.position, Quaternion.identity);
        
        AudioManager.instance.PlaySFX(6);

        Destroy(gameObject);
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
