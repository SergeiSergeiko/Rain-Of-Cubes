using UnityEngine;
using UnityEngine.Pool;

public class PoolObjects<T> : MonoBehaviour where T : MonoBehaviour
{
    [SerializeField] private int _capacity;
    [SerializeField] private int _maxCapacity;

    private ObjectPool<T> _pool;

    public void Init(T prefab)
    {
        _pool = new ObjectPool<T>(
            createFunc: () => Create(prefab),
            actionOnGet: (obj) => obj.gameObject.SetActive(true),
            actionOnRelease: (obj) => obj.gameObject.SetActive(false),
            actionOnDestroy: (obj) => Destroy(obj.gameObject),
            collectionCheck: true,
            defaultCapacity: _capacity,
            maxSize: _maxCapacity
        );
    } 

    public T Get() => _pool.Get(); //Object reference not set to an instance of an object

    public void Release(T gameObject) => _pool.Release(gameObject);

    private T Create(T prefab)
    {
        T obj = Instantiate(prefab);
        obj.transform.position = transform.position;
        obj.gameObject.SetActive(false);
        
        return obj;
    }
}