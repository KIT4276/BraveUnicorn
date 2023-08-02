using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class EnemiesFactory 
{
    [Inject]
    private Enemy.Pool _enemiesPool;

    private readonly List<Enemy> _enemies = new List<Enemy>();

    public Enemy SpawnEnemy(Transform transform)
    {
        var enemy = _enemiesPool.Spawn();

        _enemies.Add(enemy);
        enemy.transform.position = transform.position;
        enemy.Restart();

        return enemy;
    }

    public void DespawnEnemy(Enemy enemy)
    {
        _enemiesPool.Despawn(enemy);
        _enemies.Remove(enemy);
    }
}
