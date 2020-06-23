using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BluePill : MonoBehaviour
{
    public float multiplier = 1.4f; 
    
    public GameObject pickupEffect;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            other.gameObject.transform.localScale *= multiplier;
            Destroy(gameObject);
        }
    }
}
