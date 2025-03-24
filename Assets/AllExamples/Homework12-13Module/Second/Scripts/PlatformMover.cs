using UnityEngine;

public class PlatformMover : MonoBehaviour
{
    private const string HorizontalAxis = "Horizontal";
    private const string VerticalAxis = "Vertical";

    [SerializeField] private float _rotationForce;

    private Rigidbody _rigidbody;

    private float _xInput;
    private float _zInput;

    private float _deadZone = 0.05f;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        _xInput = Input.GetAxis(HorizontalAxis);
        _zInput = Input.GetAxis(VerticalAxis);
    }

    private void FixedUpdate()
    {
        if (Mathf.Abs(_xInput) >= _deadZone)
            _rigidbody.AddTorque(Vector3.back * _xInput * _rotationForce);

        if (Mathf.Abs(_zInput) >= _deadZone)
            _rigidbody.AddTorque(Vector3.right * _zInput * _rotationForce);
    }
}
