using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedPill : MonoBehaviour
{
    [SerializeField]private int _amountOfLifeGained = 10;
    private PickUp _pickUp;
    private void Start()
    {
        _pickUp = GetComponent<PickUp>();
        _pickUp.onPillEffectStart += OnEffectStart;
       // _pickUp.OnPillEffectEnd += OnEffectEnd;
    }

    private void OnEffectStart(GameObject player)
    {
        player.GetComponent<Health>().GainHealth(_amountOfLifeGained);
    }

    // private void OnEffectEnd(GameObject player)
    // {
    // }
}
