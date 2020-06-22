using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Deals damage when it touches something
public class StandardDamageDealer : MonoBehaviour
{
    private DamageDealer damageDealer;
    private void Start()
    {
        damageDealer = GetComponent<DamageDealer>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log($"Touched : {other.gameObject.name}");
        damageDealer.OnHit(other.gameObject);
    }
}
