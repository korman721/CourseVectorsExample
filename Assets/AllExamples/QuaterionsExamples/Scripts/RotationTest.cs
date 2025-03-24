using System;
using UnityEngine;

public class RotationTest : MonoBehaviour
{
    [SerializeField] private Vector3 _rotationInEulerAngles;
    [SerializeField] private Transform _aroundRotatePoint;
    [SerializeField] private Transform _anothherObject;

    [SerializeField] private float _speed;

    private void Awake()
    {
        transform.rotation = Quaternion.identity;

        transform.rotation = Quaternion.Euler(45, 0, 0) * Quaternion.Euler(45, 0, 0);

        Vector3 diraction = Quaternion.Euler(45, 0, 0) * Vector3.forward;
        transform.rotation = Quaternion.LookRotation(diraction);
    }

    private void Update()
    {
        // transform.rotation = Quaternion.Euler(_rotationInEulerAngles);

        Debug.Log($"Quaterion rotation: {transform.rotation}");
        Debug.Log($"Euler angles rotation: {transform.rotation.eulerAngles}");

        //RotateTest();

        //LookRotationTest();

        //RotateTowardsTest();
    }

    private void RotateTowardsTest()
    {
        Quaternion lookRotatin = Quaternion.LookRotation(_anothherObject.position - transform.position);
        float step = _speed * Time.deltaTime;

        transform.rotation = Quaternion.RotateTowards(transform.rotation, lookRotatin, step);
    }

    private void LookRotationTest()
    {
        transform.rotation = Quaternion.LookRotation(_anothherObject.position - transform.position);
    }

    private void RotateTest()
    {
        // transform.Rotate(Vector3.up * 10 * Time.deltaTime);

        transform.RotateAround(_aroundRotatePoint.position, Vector3.up, 10 * Time.deltaTime);
    }
}
