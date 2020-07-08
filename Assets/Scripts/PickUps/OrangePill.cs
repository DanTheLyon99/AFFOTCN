using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrangePill : MonoBehaviour
{
    
    public float multiplier = 2f; 
    
    private PickUp _pickUp;
    private PlayerMove _move;
    private float _oldMoveSpeed;
    
    private void Start()
    {
        _pickUp = GetComponent<PickUp>();
        _pickUp.onPillEffectStart += OnEffectStart;
        _pickUp.onPillEffectEnd += OnEffectEnd;
    }

    

    private void OnEffectStart(GameObject player)
    {
        _move = player.GetComponent<PlayerMove>();
        _oldMoveSpeed = _move.speed;
        _move.speed *= multiplier;
    }
    
    private void OnEffectEnd(GameObject player)
    {
        _move.speed = _oldMoveSpeed;
    }
    
}
