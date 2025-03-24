using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldToLocalSpaceTransformation : MonoBehaviour
{
    [SerializeField] private Transform _firstCube;
    [SerializeField] private Transform _secondCube;

    private void Awake()
    {
        Vector3 secondCubeLocalPosition = _firstCube.InverseTransformPoint(_secondCube.position);

        Debug.Log($"������� � ������� �����������: {_secondCube.position}");
        Debug.Log($"������� � ��������� ����������� ������������� ������� ����: {secondCubeLocalPosition}");
    }
}
