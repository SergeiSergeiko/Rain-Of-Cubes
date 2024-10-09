using System;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Unit : MonoBehaviour
{
    private Rigidbody _rigidbody;
    private int _minLifeTime = 2;
    private int _maxLifeTime = 10;

    public event Action<Unit> Dies;

    public int LifeTime { get; private set; }

    protected virtual void OnEnable()
    {
        _rigidbody = GetComponent<Rigidbody>();
        LifeTime = UnityEngine.Random.Range(_minLifeTime, _maxLifeTime);
        StartCoroutine(CountdownLifeTime());
    }

    protected virtual void Die()
    {
        ResetRigidbody();
        Dies?.Invoke(this);
    }

    private void ResetRigidbody()
    {
        _rigidbody.rotation = Quaternion.identity;
        _rigidbody.velocity = Vector3.zero;
        _rigidbody.angularVelocity = Vector3.zero;
    }


    private IEnumerator CountdownLifeTime()
    {
        float time = 0;

        while (time < LifeTime)
        {
            time += Time.deltaTime;

            yield return null;
        }

        Die();
    }
}