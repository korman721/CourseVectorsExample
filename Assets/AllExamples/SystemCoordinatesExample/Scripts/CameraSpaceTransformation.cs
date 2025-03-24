using UnityEngine;

public class CameraSpaceTransformation : MonoBehaviour
{
    private Camera _camera;

    [SerializeField] private Transform _target;

    [SerializeField] private Transform _mousePositionIndicator;
    [SerializeField] private Transform _worldPositionIndicator;


    private void Awake()
    {
        _camera = Camera.main;
    }

    private void Update()
    {
        Vector3 screenPosition = Input.mousePosition;
        _mousePositionIndicator.position = screenPosition;

        Vector3 worldPosition = _camera.ScreenToWorldPoint(screenPosition);
        _worldPositionIndicator.position = worldPosition;

        _target.position = new Vector3(worldPosition.x, worldPosition.y, _target.position.z);

        Debug.Log($" оординаты мышки - {screenPosition}, мировые координаты - {worldPosition}");
    }
}
