using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Standard projectile that moves forward
public class StandardProjectile : MonoBehaviour
{
    private Projectile projectile;
    private Rigidbody2D projectileRB;
    public float projectileSpeed = 5f;
    //TODO:ajouter un systeme ammo
    
    private void OnEnable()
    {
        projectile = GetComponent<Projectile>();
        projectileRB = GetComponent<Rigidbody2D>();
        projectile.onShoot += OnShoot;
        Destroy(gameObject,projectile.lifetime);
    }

    private void OnShoot()
    {
        projectileRB.velocity = projectileSpeed * transform.right ;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log($"Touched {other.transform.name}");
        Destroy(gameObject);
        //Projectile destruction animation
    }
}
