using System;

public class EventBus : IReadOnlySpawnStatistics
{
    public event Action ObjectSpawned;
    public event Action ObjectCreated;
    public event Action ObjectWasActivated;
    public event Action ObjectHasBeenDeactivated;

    public void TriggerObjectSpawned() => ObjectSpawned?.Invoke();

    public void TriggerObjectCreated() => ObjectCreated?.Invoke();

    public void TriggerObjectWasActivated() => ObjectWasActivated?.Invoke();

    public void TriggerObjectHasBeenDeactivated() => ObjectHasBeenDeactivated?.Invoke();
}