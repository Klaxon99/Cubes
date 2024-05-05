using UnityEngine;

public class Exploder : MonoBehaviour
{
    [SerializeField] private float _explosionForce;
    [SerializeField] private float _explosionRadius;
    [SerializeField] private LayerMask _layerMask;

    public void Detonate(Vector3 position, Rigidbody[] rigidbodies)
    {
        foreach (Rigidbody rigidbody in rigidbodies)
        {
            rigidbody.AddExplosionForce(_explosionForce, position, _explosionRadius);
        }
    }

    public void Detonate(Transform cube)
    {
        float deafaltFactor = 1f;
        float explosionFactor = deafaltFactor / cube.localScale.magnitude;
        float resultRadius = _explosionRadius * explosionFactor;
        float resultForce = _explosionForce * explosionFactor;
        Collider[] colliders = Physics.OverlapSphere(cube.transform.position, resultRadius, _layerMask);

        foreach (Collider collider in colliders)
        {
            float distanceForceFactor = Mathf.Clamp01(deafaltFactor / (collider.transform.position - cube.position).magnitude);
            collider.attachedRigidbody.AddExplosionForce(resultForce * distanceForceFactor, cube.position, resultRadius);
        }
    }
}