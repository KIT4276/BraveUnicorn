using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class EnemiesSpawner : MonoBehaviour
{
    //[SerializeField]
    //private List<Transform> _spawnPoints = new List<Transform>();
    
    [Inject]
    private EnemiesFactory _enemiesFactory;

    public void SpawnEnemy(Transform transform)
    {
        _enemiesFactory.SpawnEnemy(transform);
    }
}
