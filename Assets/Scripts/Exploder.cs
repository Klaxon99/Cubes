using UnityEngine;

public class Exploder : MonoBehaviour
{
    [SerializeField] private float _explosionForce;
    [SerializeField] private float _explosionRadius;

    public void Detonate(Vector3 position, Rigidbody[] rigidbodies)
    {
        foreach (Rigidbody rigidbody in rigidbodies)
        {
            rigidbody.AddExplosionForce(_explosionForce, position, _explosionRadius);
        }
    }
}