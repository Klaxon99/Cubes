using UnityEngine;

public class CubeDestroyer : MonoBehaviour
{
    [SerializeField] private Raycaster _raycaster;
    [SerializeField] private PlayerInput _playerInput;

    private void OnEnable()
    {
        _playerInput.Clicked += OnClicked;
    }

    private void OnDisable()
    {
        _playerInput.Clicked -= OnClicked;
    }

    private void OnClicked()
    {
        if (_raycaster.Cameracast(out Cube cube))
        {
            cube.Destroy();
        }
    }
}