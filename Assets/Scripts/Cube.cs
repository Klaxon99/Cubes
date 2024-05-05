using UnityEngine;

[RequireComponent (typeof(Transform))]
[RequireComponent (typeof(MeshRenderer))]
[RequireComponent (typeof(Divider))]
[RequireComponent (typeof(Rigidbody))]
[RequireComponent (typeof(Exploder))]
public class Cube : MonoBehaviour
{
    private Transform _transform;
    private Rigidbody _rigidbody;
    private Exploder _exploder;
    private MeshRenderer _meshRenderer;
    private Divider _divider;
    private float _divideChance = 100f;

    public Rigidbody Rigidbody => _rigidbody;

    private void Awake()
    {
        _meshRenderer = GetComponent<MeshRenderer>();
        _divider = GetComponent<Divider>();
        _transform = GetComponent<Transform>();
        _rigidbody = GetComponent<Rigidbody>();
        _exploder = GetComponent<Exploder>();
    }

    public void Initialize(Vector3 position, Vector3 scale, Material material, float divideChance)
    {
        _transform.position = position;
        _transform.localScale = scale;
        _meshRenderer.material = material;
        _divideChance = divideChance;
    }

    public void Destroy()
    {
        if (_divider.TryDivide(_divideChance, out Rigidbody[] rigidbodies))
        {
            _exploder.Detonate(_transform.position, rigidbodies);
        }

        Destroy(gameObject);
    }
}