using System;

public interface IReadOnlySpawnObjects
{
    public event Action ObjectSpawned;
    public event Action CreatedObject;
    public event Action<int> ChangedActiveObjects;
}