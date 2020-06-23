using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrangePill : MonoBehaviour
{
    
    public float multiplier = 1.4f; 
    
    public GameObject pickupEffect;

    private PlayerMove move;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        move = other.GetComponent<PlayerMove>();
        if (other.CompareTag("Player"))
        {
            move.speed *= 2;
            Destroy(gameObject);
        }
    }
}
