using System.Collections.Generic;
using UnityEngine;

public class ThiefMovement : MonoBehaviour
{
    [SerializeField] private List<Transform> _wayPoints;

    private int _currentWayPointIndex = 0;
    private float _speed = 5f;

    private void Update()
    {
        if (transform.position == _wayPoints[_currentWayPointIndex].position)
            _currentWayPointIndex = ++_currentWayPointIndex % _wayPoints.Count;

        transform.position = Vector3.MoveTowards(transform.position, _wayPoints[_currentWayPointIndex].position, _speed * Time.deltaTime);
    }
}
