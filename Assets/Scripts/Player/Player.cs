using System;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
    {
        private Health _health;
        private AudioSource _audioSource;
        [SerializeField] private Image healthBar;
        
        [SerializeField] private AudioClip hurtSound;
        
        private void Start()
        {
            _health = GetComponent<Health>();
            _audioSource = GetComponent<AudioSource>();
            _health.onTakeDamage += OnTakeDamage;
            _health.onGainHealth += OnGainHealth;
        }

        //Event that triggers only when the player takes damage
        private void OnTakeDamage(DamageDealer damageDealer)
        {
            healthBar.fillAmount = _health.currentHealth / 100;
            _audioSource.PlayOneShot(hurtSound);
        }

        private void OnGainHealth()
        {
            healthBar.fillAmount = _health.currentHealth / 100;
        }
    }
