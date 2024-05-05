using UnityEngine;

public class Raycaster : MonoBehaviour
{
    [SerializeField] private Camera _camera;

    public bool Cameracast(out Cube cube)
    {
        Ray ray = _camera.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out RaycastHit hitInfo))
        {
            Collider collider = hitInfo.collider;

            if (collider != null)
            {
                return collider.TryGetComponent(out cube);
            }
        }

        cube = null;
        return false;
    }
}