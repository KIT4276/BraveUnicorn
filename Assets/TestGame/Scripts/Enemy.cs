using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;
using Spine;
using Spine.Unity;

public class Enemy : Units
{
    [Inject]
    private EnemiesFactory _enemiesFactory;
    [Inject]
    private GraveFactory _graveFactory;
    
    public void Restart()
    {
        SetAnimation(_walkAnimation, true);
        base.Start();
    }

    public void EnemiesDeath()
    {
        Death();
    }

    protected override void AfterDeath() 
    {
        _graveFactory.SpawnGrave(transform.localPosition);
        _enemiesFactory.DespawnEnemy(this);
    }

    public class Pool : MonoMemoryPool<Enemy> { }
}
