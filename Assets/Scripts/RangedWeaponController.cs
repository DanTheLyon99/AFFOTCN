using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum  WeaponMode
{
    Manual,Automatic
}

//Class specificly for ranged weapons
public class RangedWeaponController : MonoBehaviour
{
    [SerializeField] private WeaponMode weaponMode;
    
    [SerializeField] private float timeBetweenShots;
    [SerializeField] private Projectile bulletPrefab;
     private GameObject projectileFolder;
    
    
    //Should be an array au audioclips so we can play sounds at random not the same one all the time.
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip shootSound;

    private Coroutine fire;
    private bool canShoot = true;
    
    //Dependencies
    private Weapon weapon;

    private void Start()
    {
        projectileFolder = GameObject.Find("projectileFolder");
    }

    private void OnEnable()
    {
        weapon = GetComponent<Weapon>();
        weapon.onAttack += DoShootAction;
        weapon.onStopAttack += StopAttack;
    }

    private void OnDisable()
    {
        weapon.onAttack -= DoShootAction;
    }

    private void StopAttack()
    {
        StopCoroutine(fire);
    }
    private void DoShootAction()
    {
        switch (weaponMode)
        {
            case WeaponMode.Manual:
                if(canShoot)
                    StartCoroutine(HandleShootManual());
                break;
            case WeaponMode.Automatic:
                    fire = StartCoroutine(HandleShootAutomatic());
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }

    private IEnumerator HandleShootAutomatic()
    {
        //The coroutine stop when the fire button is released
        while (true)
        {
            CreateProjectile();
            yield return new WaitForSeconds(timeBetweenShots);
        }
    }

    private IEnumerator HandleShootManual()
    {
        CreateProjectile();
        canShoot = false;
        yield return new WaitForSeconds(timeBetweenShots);
        canShoot = true;
    }
    
    
    private void CreateProjectile()
    {
        //Add verification if we add ammo
        audioSource.PlayOneShot(shootSound);
        Projectile newProjectile = Instantiate(bulletPrefab, transform.position,transform.rotation,projectileFolder.transform);
        newProjectile.GetComponent<DamageDealer>().Damage= weapon.damage;
        newProjectile.Shoot(gameObject);
    }
}
