using System;
using UnityEngine;

public class ObjectStatistics : MonoBehaviour
{
    private IReadOnlySpawnObjects _eventBus;

    public event Action<int> NumberObjectsCreatedChanged;
    public event Action<int> NumberSpawnedObjectsChanged;
    public event Action<int> NumberActiveObjectsChanged;

    public int NumberObjectsCreated { get; private set; }
    public int NumberSpawnedObjects { get; private set; }
    public int NumberActiveObjects { get; private set; }

    public void InitEventBus(IReadOnlySpawnObjects eventBus)
    {
        _eventBus = eventBus;

        _eventBus.ObjectSpawned += IncreaseNumberSpawnedObjects;
        _eventBus.ChangedActiveObjects += OnNumberActiveObjectsHandler;
        _eventBus.CreatedObject += IncreaseNumberObjectsCreated;
    }

    private void IncreaseNumberObjectsCreated()
    {
        NumberObjectsCreated++;
        NumberObjectsCreatedChanged?.Invoke(NumberObjectsCreated);
    }
    private void IncreaseNumberSpawnedObjects()
    { 
        NumberSpawnedObjects++;
        NumberSpawnedObjectsChanged?.Invoke(NumberSpawnedObjects);
    }
    private void OnNumberActiveObjectsHandler(int count)
    {
        NumberActiveObjects = count;
        NumberActiveObjectsChanged?.Invoke(NumberActiveObjects);
    }
}