using UnityEngine;
using System.Collections.Generic;

public class Bomb : Unit
{
    [SerializeField] private float _explotionRadius;
    [SerializeField] private float _explotionForce;
    [SerializeField] private ParticleSystem _explosionEffect;

    protected override void Die()
    {
        Instantiate(_explosionEffect, transform.position, Quaternion.identity);
        Explode();

        base.Die();
    }

    private void Explode()
    {
        List<Rigidbody> objects = GetExplodableObjects();

        foreach (Rigidbody obj in objects)
            obj.AddExplosionForce(_explotionForce, transform.position, _explotionRadius);
    }

    private List<Rigidbody> GetExplodableObjects()
    {
        List<Rigidbody> objects = new List<Rigidbody>();

        Collider[] hits = Physics.OverlapSphere(transform.position, _explotionRadius);

        foreach (var hit in hits)
            if (hit.attachedRigidbody != null)
                objects.Add(hit.attachedRigidbody);

        return objects;
    }
}