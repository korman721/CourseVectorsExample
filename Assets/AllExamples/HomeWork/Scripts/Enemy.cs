using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private const float MinDistanceToTarget = 0.5f;

    [SerializeField] private float _speed;
    [SerializeField] private float _rotationSpeed;

    [SerializeField] private RandomPointsGenerator _randomPointsGenerator;

    private CharacterController _characterController;
    private RotateTo _rotateTo;
    private Mover _mover;

    private Queue<Vector3> _targetsQueue;

    private Vector3 _currentTarget;
    private Vector3 _startPosition;

    private void Awake()
    {
        _rotateTo = new RotateTo();
        _mover = new Mover();

        _characterController = GetComponent<CharacterController>();

        _startPosition = transform.position;

        _targetsQueue = _randomPointsGenerator.GenerateRandomPoints();

        SwitchTarget();
    }

    private void Update()
    {
        Vector3 direction = GetDirectionToTargetPoint();

        if (direction.magnitude <= MinDistanceToTarget)
            SwitchTarget();

        Vector3 normalizedDirection = direction.normalized;

        _mover.ProcessMoveTo(normalizedDirection, _characterController, _speed);

        _rotateTo.ProcessRotateTo(normalizedDirection, _rotationSpeed, transform);
    }

    private void SwitchTarget()
    {
        _currentTarget = _targetsQueue.Dequeue();
        _targetsQueue.Enqueue(_currentTarget);
    }

    private Vector3 GetDirectionToTargetPoint() => _currentTarget - transform.position;

    public void SetNewRandomPoints()
    {
        _randomPointsGenerator.ClearPoints();

        _targetsQueue.Clear();

        _targetsQueue = _randomPointsGenerator.GenerateRandomPoints();

        SwitchTarget();
    }

    public void SetStartPosition() => transform.position = _startPosition;
}
