using UnityEngine;

public class SystemCoordinatesDemonstartion : MonoBehaviour
{
    private void Awake()
    {
        Debug.Log($"Позиция в мировых координатах: {transform.position}");
        Debug.Log($"Позиция в координатах родителя (Локальных): {transform.localPosition}");
    }

    private void Update()
    {
        // transform.localPosition += new Vector3(1, 0, 0) * Time.deltaTime; 
    }
}
