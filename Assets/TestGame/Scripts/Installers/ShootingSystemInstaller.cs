using UnityEngine;
using Zenject;

public class ShootingSystemInstaller : MonoInstaller
{
    [SerializeField]
    private GameObject _shootingSystemPrefab;


    public override void InstallBindings()
    {
        ShootingSystem shootingSystemInstance = Container.InstantiatePrefabForComponent<ShootingSystem>
            (_shootingSystemPrefab, Vector3.zero, Quaternion.identity, null);
        Container.Bind<ShootingSystem>().FromInstance(shootingSystemInstance).AsSingle();
    }
}