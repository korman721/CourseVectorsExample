using UnityEngine;

public class UpdateDebugTest : MonoBehaviour
{
    private void Update()
    {
        Debug.Log($"UpdateCall - {Time.time}");
    }

    private void FixedUpdate()
    {
        Debug.Log($"FixedUpdateCall - {Time.time}");
    }
}
