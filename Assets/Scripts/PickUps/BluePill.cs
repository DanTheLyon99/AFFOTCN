using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BluePill : MonoBehaviour
{
    private PickUp _pickUp;
    public float multiplier = 1.4f;
    


    private void Start()
    {
        _pickUp = GetComponent<PickUp>();
        _pickUp.onPillEffectStart += OnEffectStart;
        _pickUp.onPillEffectEnd += OnEffectEnd;
    }

    private void OnEffectStart(GameObject player)
    {
       player.transform.localScale *= multiplier;
    }

    private void OnEffectEnd(GameObject player)
    {
        player.transform.localScale = new Vector3(-1,1,1);
        
        
    }
   
}
