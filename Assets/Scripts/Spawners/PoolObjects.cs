using System;
using UnityEngine;
using UnityEngine.Pool;

public class PoolObjects<T> : MonoBehaviour where T : MonoBehaviour
{
    [SerializeField] private T _prefab;
    [SerializeField] private int _capacity;
    [SerializeField] private int _maxCapacity;

    private ObjectPool<T> _pool;
    private EventBus _eventBus;

    private void Awake()
    {
        _pool = new ObjectPool<T>(
            Create, OnGet, OnRelease, OnDestroyObj,
            collectionCheck: true,
            defaultCapacity: _capacity,
            maxSize: _maxCapacity
        );
    }

    public void InitEventBus(EventBus eventBus)
    {
        _eventBus = eventBus;
    }

    public T Get()
    {
        return _pool.Get();
    }

    public void Release(T obj)
    {
        _pool.Release(obj);
    }

    private T Create()
    {
        T obj = Instantiate(_prefab);
        _eventBus.TriggerCreatedObject();

        return obj;
    }

    private void OnGet(T obj)
    {
        obj.gameObject.SetActive(true);
        _eventBus.TriggerChangedActiveObjects(_pool.CountActive);
    }

    private void OnRelease(T obj)
    {
        obj.gameObject.SetActive(false);
    }

    private void OnDestroyObj(T obj)
    {
        Destroy(obj);
    }
}