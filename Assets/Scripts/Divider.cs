using UnityEngine;

public class Divider : MonoBehaviour
{
    [SerializeField] private int _minSpawnCount;
    [SerializeField] private int _maxSpawnCount;
    [SerializeField] private float _divideChanceFactor;
    [SerializeField] private CubeCreator _cubeCreator;
    [SerializeField] private Transform _transform;
    
    public bool TryDivide(float divideChance, out Rigidbody[] rigidbodies)
    {
        bool canDivide = CheckDivideChance(divideChance);

        if (canDivide)
        {
            int spwanCount = Random.Range(_minSpawnCount, _maxSpawnCount);
            rigidbodies = new Rigidbody[spwanCount];

            for (int i = 0; i < spwanCount; i++)
            {
                Cube cube = _cubeCreator.CreateCube(_transform, divideChance * _divideChanceFactor);
                rigidbodies[i] = cube.Rigidbody;
            }

            return canDivide;
        }

        rigidbodies = null;
        return false;
    }

    private bool CheckDivideChance(float divideChance)
    {
        int minValue = 1;
        int maxValue = 101;
        
        int resultValue = Random.Range(minValue, maxValue);

        return resultValue <= divideChance;
    }
}