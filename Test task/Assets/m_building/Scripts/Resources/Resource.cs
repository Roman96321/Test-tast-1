public class Resource : IResource
{
    private int _count { get; set; }

    public ResourceType Type {get;}
    public int Count {get => _count; set {_count = value;}}

    public Resource(ResourceType type, int defaultAmount = default)
    {
        Type = type;
        Count = defaultAmount;
    }
}