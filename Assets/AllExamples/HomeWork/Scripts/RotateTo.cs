using UnityEngine;

public class RotateTo
{
    public void ProcessRotateTo(Vector3 diraction, float rotationSpeed, Transform transform)
    {
        Quaternion lookRotatin = Quaternion.LookRotation(diraction);
        float step = rotationSpeed * Time.deltaTime;

        transform.rotation = Quaternion.RotateTowards(transform.rotation, lookRotatin, step);
    }
}
