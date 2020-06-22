using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public GameObject Owner { get; set; }
    public int Damage { get; set; }
    public float lifetime = 2f;

    public Action onShoot;

    public void Shoot(GameObject owner)
    {
        Owner = owner;
        onShoot?.Invoke();
    }
}
