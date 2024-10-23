using System.Collections;
using UnityEngine;

public class CubeSpawner : GenericSpawner<Cube>
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
        cube.Died += _bombSpawner.Spawn;
        cube.Died += CubeDiedHandler;
    }

    private void CubeDiedHandler(Unit unit)
    {
        if (unit is Cube cube)
        {
            cube.Died -= CubeDiedHandler;
            Pool.Release(cube);
        }
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