using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField]private Weapon equipedWeapon;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            equipedWeapon.Attack();
        }

        if (Input.GetButtonUp("Fire1"))
        {
            equipedWeapon.StopAttack();
        }
    }
    
    
}
