using System.Collections;
using UnityEngine;

public class Spawner<T> : MonoBehaviour where T : MonoBehaviour
{
    [SerializeField] private T _prefab;
    [SerializeField] private Transform[] _spawnPoints;
    [SerializeField] private float _delay;
    [SerializeField] private PoolObjects<T> _pool;

    private bool _isSpawn = true;

    private void Start()
    {
        StartCoroutine(Spawning());
        _pool.Init(_prefab);
    }

    private IEnumerator Spawning()
    {
        WaitForSeconds wait = new WaitForSeconds(_delay);
        int counter = 0;

        while (_isSpawn)
        {
            Vector3 position = _spawnPoints[counter++ % _spawnPoints.Length].position;
            Spawn(position);

            yield return wait;
        }
    }

    private void Spawn(Vector3 position)
    {
        T obj = _pool.Get();
        obj.transform.position = position;
    }
}