using Zenject;

public class EnemyHealth : BaseHealth
{
    [Inject] private ResourceFeatures _resourceFeatures;

    private int _gold = 1;

    public override void isDie()
    {
        if (_health <= 0)
        {
            _resourceFeatures.AddResource(ResourceType.Gold, _gold);
            Destroy(gameObject);
        }           
    }
}