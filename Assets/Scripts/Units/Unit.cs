using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Unit : MonoBehaviour
{
    [SerializeField] private Timer _timer;

    private Rigidbody _rigidbody;
    private int _minLifeTime = 2;
    private int _maxLifeTime = 5;

    public event Action<Unit> Died;

    public int LifeTime { get; private set; }

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    protected virtual void Die()
    {
        ResetRigidbody();
        Died?.Invoke(this);
    }

    protected void StartLifeTimer()
    {
        LifeTime = UnityEngine.Random.Range(_minLifeTime, _maxLifeTime);

        _timer.TimeIsUp += OnEventTimerIsUp;
        _timer.StartTimer(LifeTime);
    }

    private void OnEventTimerIsUp()
    {
        _timer.TimeIsUp -= OnEventTimerIsUp;

        Die();
    }

    private void ResetRigidbody()
    {
        _rigidbody.rotation = Quaternion.identity;
        _rigidbody.velocity = Vector3.zero;
        _rigidbody.angularVelocity = Vector3.zero;
    }
}