using TMPro;
using UnityEngine;

public class DistanceDetector : MonoBehaviour
{
    [SerializeField] private Transform _firstPoint;
    [SerializeField] private Transform _secondPoint;

    [SerializeField] private TMP_Text _distanceText;

    [SerializeField] private float _minDistanceForDetect;

    private void Update()
    {
        Vector3 direction = _secondPoint.position - _firstPoint.position;

        float distance = direction.magnitude;

        _distanceText.text = distance.ToString("0.00");

        if (direction.magnitude < _minDistanceForDetect)
        {
            _distanceText.color = Color.red;
            Debug.DrawLine(_firstPoint.position, _secondPoint.position, Color.red);
        }
        else
        {
            _distanceText.color = Color.white;
            Debug.DrawLine(_firstPoint.position, _secondPoint.position, Color.white);
        }
    }
}
