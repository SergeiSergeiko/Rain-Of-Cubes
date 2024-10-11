using System;

public interface IReadOnlySpawnStatistics
{
    public event Action ObjectSpawned;
    public event Action ObjectCreated;
    public event Action ObjectWasActivated;
    public event Action ObjectHasBeenDeactivated;
}