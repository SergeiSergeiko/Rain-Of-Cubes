using UnityEngine;

[RequireComponent (typeof(BoxCollider))]
public class Platform : MonoBehaviour
{
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.TryGetComponent(out Cube cube))
        {
            cube.CollidePlatformTrigger();
        }
    }
}