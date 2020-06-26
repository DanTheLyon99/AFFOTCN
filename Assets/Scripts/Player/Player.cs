using System;
using UnityEngine;

    public class Player : MonoBehaviour
    {
        private Health _health;
        private AudioSource _audioSource;
        [SerializeField] private AudioClip hurtSound;
        
        private void Start()
        {
            _health = GetComponent<Health>();
            _audioSource = GetComponent<AudioSource>();
            _health.onTakeDamage += OnTakeDamage;
        }

        //Event that triggers only when the player takes damage
        private void OnTakeDamage(DamageDealer damageDealer)
        {
            _audioSource.PlayOneShot(hurtSound);
        }
    }
