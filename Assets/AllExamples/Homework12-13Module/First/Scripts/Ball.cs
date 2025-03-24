using UnityEngine;

public class Ball : MonoBehaviour
{
    private const string HorizontalAxis = "Horizontal";
    private const string VerticalAxis = "Vertical";

    [SerializeField] private float _movementForce;
    [SerializeField] private float _jumpForce;

    private Rigidbody _rigidbody;
    private float _xInput;
    private float _zInput;

    private float _deadZone = 0.05f;
    private float _jumpZone = 0.1f;

    private bool _isGrounded;
    private bool _readyToJump;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        _xInput = Input.GetAxisRaw(HorizontalAxis);
        _zInput = Input.GetAxisRaw(VerticalAxis);

        if (Input.GetKeyDown(KeyCode.Space) && _isGrounded)
        {
            _readyToJump = true;
        }
    }

    private void FixedUpdate()
    {
        if (Mathf.Abs(_xInput) > _deadZone)
        {
            _rigidbody.AddForce(Vector3.right * _xInput * _movementForce);

        }

        if (Mathf.Abs(_zInput) > _deadZone)
        {
            _rigidbody.AddForce(Vector3.forward * _zInput * _movementForce);
        }

        if (_readyToJump)
        {
            _rigidbody.AddForce(Vector3.up * _jumpForce, ForceMode.Impulse);
            _readyToJump = false;
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        ContactPoint contactPoint = collision.contacts[0];

        if (Mathf.Abs(contactPoint.point.x - transform.position.x) <= _jumpZone)
        {
            _isGrounded = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        _isGrounded = false;
    }
}
