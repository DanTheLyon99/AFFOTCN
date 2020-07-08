using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sanity : MonoBehaviour
{
    //ONLY FOR THE PLAYER
    [SerializeField] private Image sanityBar;
    
    [SerializeField]private float _sanityLostPerSecond = 0.5f;

    public float CurrentSanity { get; private set; }

    [SerializeField] private float maxSanity = 100;
    
    public bool sanityLowersOverTime = false;
    public Action onTakeSanityDamage;

    private void Start()
    {
        CurrentSanity = maxSanity;
    }

    void Update()
    {
        if (sanityLowersOverTime)
        {
            TakeSanityDamage(Time.deltaTime * _sanityLostPerSecond);
        }
       
    }

    public void TakeSanityDamage(float amount)
    {
        CurrentSanity -= amount;
        CurrentSanity = Mathf.Clamp(CurrentSanity, 0f, maxSanity);
        onTakeSanityDamage?.Invoke();
        UpdateSanityBar();
    }

    public void GainSanity(float amount)
    {
        CurrentSanity += amount;
        CurrentSanity = Mathf.Clamp(CurrentSanity, 0f, maxSanity);
        UpdateSanityBar();
    }

    private void UpdateSanityBar()
    {
        sanityBar.fillAmount = CurrentSanity / 100;
    }
}
