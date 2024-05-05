using UnityEngine;

public class CubeCreator : MonoBehaviour
{
    [SerializeField] private Cube _cubePrefab;
    [SerializeField] private Material[] _materials;
    [SerializeField] private float _scaleFactor = 0.5f;

    public Cube CreateCube(Transform parentCube, float divideChance)
    {
        Cube cube = Instantiate(_cubePrefab);
        cube.Initialize(parentCube.position, parentCube.localScale * _scaleFactor, GetRandomMaterial(), divideChance);

        return cube;
    }

    private Material GetRandomMaterial()
    {
        int minIndex = 0;
        int randomIndex = Random.Range(minIndex, _materials.Length);

        return _materials[randomIndex];
    }
}