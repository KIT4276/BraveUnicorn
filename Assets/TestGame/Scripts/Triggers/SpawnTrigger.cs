using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class SpawnTrigger : MonoBehaviour
{
    [SerializeField]
    private Transform _spawnPoint;
    [SerializeField]
    private EnemiesSpawner _enemiesSpawner;
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        _enemiesSpawner.SpawnEnemy(_spawnPoint);
        this.gameObject.SetActive(false);
    }
}
