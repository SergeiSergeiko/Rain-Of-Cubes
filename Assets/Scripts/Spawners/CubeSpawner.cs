using System.Collections;
using UnityEngine;

public class CubeSpawner : Spawner<Cube>
{
    [SerializeField] private Transform[] _spawnPoints;
    [SerializeField] private float _delay;
    [SerializeField] private BombSpawner _bombSpawner;

    private bool _isSpawn = true;
    private int _counter = 0;

    protected override void Start()
    {
        base.Start();
        StartCoroutine(Spawning());
    }

    protected override void Subscribe(Cube cube)
    {
        cube.Dies += _bombSpawner.OwnerDiedHandler;
        cube.Dies += CubeDiedHandler;
    }

    private void CubeDiedHandler(Unit unit)
    {
        if (unit is Cube cube)
            Pool.Release(cube);
    }

    private IEnumerator Spawning()
    {
        WaitForSeconds wait = new WaitForSeconds(_delay);

        while (_isSpawn)
        {
            Vector3 position = GetSpawnPosition();
            Spawn(position);

            yield return wait;
        }
    }

    private Vector3 GetSpawnPosition()
    {
        return _spawnPoints[_counter++ % _spawnPoints.Length].position;
    }
}