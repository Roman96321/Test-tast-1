using System.Collections.Generic;
using System.Linq;
using System;

public class ResourceFeatures
{
    public event Action<ResourceType, int> onChanged;

    public readonly Dictionary<ResourceType, Resource> _resources;

    public ResourceFeatures(Resource[] resources)
    {
        _resources = resources.ToDictionary(r => r.Type);
    }

    public void AddResource(ResourceType type, int value)
    {
        var recource = _resources[type];
        recource.Count += value;

        onChanged.Invoke(type, recource.Count);
    }

    public void SpendResource(ResourceType type, int value)
    {
        var recource = _resources[type];
        recource.Count -= value;

        onChanged.Invoke(type, recource.Count);
    }

    public bool HasResources(ResourceType type, int value)
    {
        var recource = _resources[type];
        return recource.Count >= value;
    }

    public int GetResource(ResourceType type) 
    { 
        return _resources[type].Count; 
    }
}