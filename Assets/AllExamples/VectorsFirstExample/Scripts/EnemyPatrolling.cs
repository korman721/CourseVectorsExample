using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrolling : MonoBehaviour
{
    private const float MinDistanceToTarget = 0.05f;

    [SerializeField] private float _speed;
    [SerializeField] private float _rotationSpeed;
    [SerializeField] private float _agroDistance;

    [SerializeField] private List<Transform> _targets;
    [SerializeField] private Transform _heroTarget;

    private Queue<Vector3> _targetPosition;

    private Vector3 _currentTarget;

    private void Awake()
    {
        _targetPosition = new Queue<Vector3>();

        foreach (Transform target in _targets)
            _targetPosition.Enqueue(target.position);

        SwitchTarget();
    }

    private void Update()
    {
        Vector3 direction = GetDirectionToHero();

        if (direction.magnitude > _agroDistance)
        {
            direction = GetDirectionToTargetPoint();

            if (direction.magnitude <= MinDistanceToTarget)
                SwitchTarget();
        }

        Vector3 normalizedDirection = direction.normalized;

        ProcessMoveTo(normalizedDirection);
        ProcessRotateTo(normalizedDirection);
    }

    private Vector3 GetDirectionToHero() => _heroTarget.position - transform.position;

    private Vector3 GetDirectionToTargetPoint() => _currentTarget - transform.position;

    private void ProcessMoveTo(Vector3 normalizedDirection)
    {
        transform.Translate(normalizedDirection * _speed * Time.deltaTime, Space.World);

        Debug.DrawRay(transform.position, normalizedDirection, Color.red);
    }

    private void ProcessRotateTo(Vector3 diraction)
    {
        Quaternion lookRotatin = Quaternion.LookRotation(diraction);
        float step = _rotationSpeed * Time.deltaTime;

        transform.rotation = Quaternion.RotateTowards(transform.rotation, lookRotatin, step);
    }

    private void SwitchTarget()
    {
        _currentTarget = _targetPosition.Dequeue();
        _targetPosition.Enqueue(_currentTarget);
    }
}
