using System;
using System.Collections;
using System.Collections.Generic;
using Pathfinding;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Rigidbody2D _enemyRb;
    private Health _health;
    private Animator _animator;
    private AudioSource _audioSource;
    private AIDestinationSetter _destinationSetter;
    [SerializeField]private AudioClip _hurtSound;
    private static readonly int TakeDamage = Animator.StringToHash("TakeDamage");

    private void Start()
    {
        _enemyRb = GetComponent<Rigidbody2D>();
        _health = GetComponent<Health>();
        _audioSource = GetComponent<AudioSource>();
        _animator = GetComponent<Animator>();
        _health.onTakeDamage += OnTakeDamage;

    }

    // Update is called once per frame
    void Update()
    {
        _enemyRb.angularVelocity = 0;
    }

    private void OnTakeDamage(DamageDealer damageDealer)
    {
        if(!_audioSource.isPlaying)
            _audioSource.PlayOneShot(_hurtSound);
        
        _animator.SetBool(TakeDamage,true);
    }

    private void EndAnimation()
    {
        Debug.Log("Set bool to false");
        _animator.SetBool(TakeDamage,false);
    }
}
