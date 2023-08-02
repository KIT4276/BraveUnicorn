using UnityEngine;
using Zenject;

public class GraveFactoryInstaller : MonoInstaller
{
    [SerializeField]
    private Grave _gravePrefab;

    public override void InstallBindings()
    {
        Container.Bind<GraveFactory>().AsSingle();
        Container.BindMemoryPool<Grave, Grave.Pool>().FromComponentInNewPrefab(_gravePrefab);
    }
}