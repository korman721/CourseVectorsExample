using UnityEngine;

public class SystemCoordinatesDemonstartion : MonoBehaviour
{
    private void Awake()
    {
        Debug.Log($"������� � ������� �����������: {transform.position}");
        Debug.Log($"������� � ����������� �������� (���������): {transform.localPosition}");
    }

    private void Update()
    {
        // transform.localPosition += new Vector3(1, 0, 0) * Time.deltaTime; 
    }
}
