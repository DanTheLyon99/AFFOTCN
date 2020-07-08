using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemySpawnerScript : MonoBehaviour
{
    public GameObject enemy;
    private Player player;
    private Sanity playerSanity;
    private float randX;
    private Vector2 whereToSpawn;

    private bool _spawner1Triggered;
    private bool _spawner2Triggered;
    private bool _spawner3Triggered;

    private void Start()
    {
        player = FindObjectOfType<Player>();
        playerSanity = player.GetComponent<Sanity>();
        playerSanity.onTakeSanityDamage += OnTakeSanityDamage;
    }



    private void OnTakeSanityDamage()
    {
        if ( !_spawner1Triggered && playerSanity.CurrentSanity > 25 && playerSanity.CurrentSanity <= 50 )
        {
            _spawner1Triggered = true;
            SpawnEnemy(3);
        }
        else if (!_spawner2Triggered && playerSanity.CurrentSanity > 10 && playerSanity.CurrentSanity <= 25)
        {
            _spawner2Triggered = true;
            SpawnEnemy(5);
        }
        else if (!_spawner3Triggered && playerSanity.CurrentSanity <= 10)
        {
            _spawner3Triggered = true;
            SpawnEnemy(8);
        }
    }


    private void SpawnEnemy(int amount)
    {
        Debug.Log(playerSanity.CurrentSanity);
        for (int i = 0; i < amount; i++)
        {
            randX = Random.Range(-8.4f, 8.4f);
            whereToSpawn =new Vector2(randX, transform.position.y);
            Instantiate(enemy, whereToSpawn, Quaternion.identity);
        }
       
    }
}
