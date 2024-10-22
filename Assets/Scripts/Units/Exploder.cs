using System.Collections.Generic;
using UnityEngine;

public class Exploder : MonoBehaviour
{
    [SerializeField] private float _explotionRadius;
    [SerializeField] private float _explotionForce;

    public void Explode()
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