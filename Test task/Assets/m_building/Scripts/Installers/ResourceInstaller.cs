using Zenject;

public class ResourceInstaller : MonoInstaller
{
    private ResourceFeatures _resoucesFeatures;

    public override void InstallBindings()
    {
        var goldResource = new Resource(ResourceType.Gold);

        var resources = new[] { goldResource};
        _resoucesFeatures = new ResourceFeatures(resources);

        Container.Bind<ResourceFeatures>().FromInstance(_resoucesFeatures).AsSingle().NonLazy();
    }
}