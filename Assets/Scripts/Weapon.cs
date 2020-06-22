using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    //General class for weapons(what every weapon has)
    [SerializeField] public int damage = 10;
    
    public Action onAttack;
    public Action onStopAttack;
    
    

    public void Attack()
    {
        onAttack?.Invoke();
    }

    public void StopAttack()
    {
        onStopAttack?.Invoke();
    }
}
