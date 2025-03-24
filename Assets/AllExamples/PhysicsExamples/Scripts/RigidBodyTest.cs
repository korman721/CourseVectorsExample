using Unity.VisualScripting;
using UnityEngine;

public class RigidBodyTest : MonoBehaviour
{
    private Rigidbody _rigidbody;

    private bool _isJumpKeyPressed;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();

        Application.targetFrameRate = 200;
        //Application.targetFrameRate = 30;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            _isJumpKeyPressed = true;
    }

    private void FixedUpdate()
    {
        if (_isJumpKeyPressed)
        {
            _rigidbody.AddForce(Vector3.up * 5, ForceMode.Impulse);
            _isJumpKeyPressed = false;
        }

        //if (Input.GetKey(KeyCode.F))
        //{
        //    _rigidbody.AddForce(Vector3.forward * 10);
        //}
    }
}
