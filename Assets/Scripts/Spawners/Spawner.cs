using UnityEngine;

public class Spawner<T> : MonoBehaviour where T : MonoBehaviour
{
    [SerializeField] protected T Prefab;
    [SerializeField] protected PoolObjects<T> Pool;

    [SerializeField] private ObjectStatistics _objectStatistics;

    private EventBus _eventBus;

    protected virtual void Start()
    {
        EventBus eventBus = new();
        _eventBus = eventBus;

        _objectStatistics.InitEventBus(_eventBus);
        Pool.InitEventBus(eventBus);
    }

    protected virtual void Spawn(Vector3 position)
    {
        T obj = GetObject();
        Subscribe(obj);
        obj.transform.position = position;
        _eventBus.TriggerObjectSpawned();
    }

    protected virtual T GetObject()
    {
        return Pool.Get();
    }

    protected virtual void Subscribe(T Obj) { }
}