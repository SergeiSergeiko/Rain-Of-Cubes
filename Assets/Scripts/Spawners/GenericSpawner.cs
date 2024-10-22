using UnityEngine;

public class GenericSpawner<T> : MonoBehaviour where T : MonoBehaviour
{
    [SerializeField] protected T Prefab;
    [SerializeField] protected GenericPoolObjects<T> Pool;
    [SerializeField] protected ObjectStatistics ObjectStatistics;

    private EventBus _eventBus;

    protected virtual void Start()
    {
        _eventBus = new();

        ObjectStatistics.InitEventBus(_eventBus);
        Pool.InitEventBus(_eventBus);
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