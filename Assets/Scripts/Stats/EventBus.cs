using System;

public class EventBus : IReadOnlySpawnObjects
{
    public event Action ObjectSpawned;
    public event Action CreatedObject;
    public event Action<int> ChangedActiveObjects;

    public void TriggerObjectSpawned() => ObjectSpawned?.Invoke();
    public void TriggerCreatedObject() => CreatedObject?.Invoke();
    public void TriggerChangedActiveObjects(int count) => ChangedActiveObjects?.Invoke(count);
}