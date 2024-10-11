using System;
using UnityEngine;

public class ObjectStatistics : MonoBehaviour
{
    private IReadOnlySpawnStatistics _eventBus;

    public event Action<int> NumberCreatedObjectsHasChanged;
    public event Action<int> NumberSpawnedObjectsHasChanged;
    public event Action<int> NumberActiveObjectsHasChanged;

    public int NumberObjectsCreated { get; private set; }
    public int NumberSpawnedObjects { get; private set; }
    public int NumberActiveObjects { get; private set; }

    public void InitEventBus(IReadOnlySpawnStatistics eventBus)
    {
        _eventBus = eventBus;

        _eventBus.ObjectCreated += IncreaseNumberObjectsCreated;
        _eventBus.ObjectSpawned += IncreaseNumberSpawnedObjects;
        _eventBus.ObjectWasActivated += IncreaseNumberActiveObjects;
        _eventBus.ObjectHasBeenDeactivated += DecreaseNumberActiveObjects;
    }

    private void IncreaseNumberObjectsCreated()
    {
        NumberObjectsCreated++;
        NumberCreatedObjectsHasChanged?.Invoke(NumberObjectsCreated);
    }

    private void IncreaseNumberSpawnedObjects()
    { 
        NumberSpawnedObjects++;
        NumberSpawnedObjectsHasChanged?.Invoke(NumberSpawnedObjects);
    }

    private void IncreaseNumberActiveObjects()
    {
        NumberActiveObjects++;
        NumberActiveObjectsHasChanged?.Invoke(NumberActiveObjects);
    }

    private void DecreaseNumberActiveObjects()
    {
        NumberActiveObjects--;
        NumberActiveObjectsHasChanged?.Invoke(NumberActiveObjects);
    }
}