using UnityEngine;
using Zenject;

public class EnemiesFactoryInstaller : MonoInstaller
{
    [SerializeField]
    private Enemy _enemyPrefab;
    
    public override void InstallBindings()
    {
        Container.Bind<EnemiesFactory>().AsSingle();
        Container.BindMemoryPool<Enemy, Enemy.Pool>().FromComponentInNewPrefab(_enemyPrefab);
    }
}