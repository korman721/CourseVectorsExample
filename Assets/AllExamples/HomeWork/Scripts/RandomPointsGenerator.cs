using System.Collections.Generic;
using UnityEngine;

public class RandomPointsGenerator : MonoBehaviour
{
    [SerializeField] private float _minXRandomPointDistance;
    [SerializeField] private float _maxXRandomPointDistance;
    [SerializeField] private float _minZRandomPointDistance;
    [SerializeField] private float _maxZRandomPointDistance;

    [SerializeField] private int _countOfRandomPoints;

    [SerializeField] private GameObject _flag;

    private List<GameObject> _flagsList;

    private Queue<Vector3> _targetsQueue;

    private int _startCountOfRandomPoints;

    private void Awake()
    {
        _targetsQueue = new Queue<Vector3>();
        _flagsList = new List<GameObject>();

        _startCountOfRandomPoints = _countOfRandomPoints;
    }

    public Queue<Vector3> GenerateRandomPoints()
    {
        while (_countOfRandomPoints > 0)
        {
            Vector3 positionOfRandomPoint = new Vector3(Random.Range(_minXRandomPointDistance, _maxXRandomPointDistance), 0, Random.Range(_minZRandomPointDistance, _maxZRandomPointDistance));
            
            GameObject flag = Instantiate(_flag, positionOfRandomPoint, Quaternion.identity);
            _flagsList.Add(flag);

            _targetsQueue.Enqueue(positionOfRandomPoint);
            _countOfRandomPoints--;
        }
        return _targetsQueue;
    }

    public void ClearPoints()
    {
        _targetsQueue.Clear();

        foreach (GameObject flag in _flagsList)
            Destroy(flag);

        _flagsList.Clear();

        _countOfRandomPoints = _startCountOfRandomPoints;
    }
}