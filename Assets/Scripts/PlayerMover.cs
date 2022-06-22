using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Serialization;

public class PlayerMover : MonoBehaviour
{
    [FormerlySerializedAs("Points")] [SerializeField]
    private List<EnemySpot> _points = new List<EnemySpot>();
    [SerializeField] List<GameObject> _wayPointsList = new List<GameObject>();
    private AbstractWaypoint _waypoint;
    private GameObject _nextPoint;
    private NavMeshAgent _mesh;

    public float speed;
    
    public event Action LevelCompleteEvent;
    private void Start()
    {
        _mesh = GetComponent<NavMeshAgent>();
        foreach (var vPoints in _points)
        {
            vPoints.SpotIsClearEvent+= Next;
        }
    }

    private void Update()
    {
        speed = _mesh.remainingDistance;
        if (speed > 5)
        {
            _mesh.speed = 15;
        }
        else
        {
            _mesh.speed = 3.5f;
        }
    }

    private void Next()
    {
        
        _points.Remove(_points[0]);
        if (_wayPointsList.Count>0)
        {    
            _nextPoint = _wayPointsList[0].gameObject;
            _mesh.SetDestination(_nextPoint.transform.position);
            _wayPointsList.Remove(_wayPointsList[0]);
        }
        
        if (_points.Count > 0)
        {
            _points[0].gameObject.SetActive(true);
        }
        
        if (_points.Count < 1)
        {
            LevelCompleteEvent?.Invoke();
        }
        
    }
}
