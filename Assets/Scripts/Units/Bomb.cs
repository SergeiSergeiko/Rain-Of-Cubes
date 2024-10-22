using UnityEngine;

public class Bomb : Unit
{
    [SerializeField] private Exploder _exploder;
    [SerializeField] private ColorChanger _colorChanger;
    [SerializeField] private ParticleSystem _explosionEffect;

    private void OnEnable()
    {
        StartLifeTimer();
        _colorChanger.SetTransparentColor(LifeTime);
    }

    private void OnDisable()
    {
        _colorChanger.ResetColor();
    }

    protected override void Die()
    {
        Instantiate(_explosionEffect, transform.position, Quaternion.identity);
        _exploder.Explode();

        base.Die();
    }
}