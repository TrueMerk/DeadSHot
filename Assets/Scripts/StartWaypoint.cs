using UnityEngine;
using UnityEngine.AI;

public class StartWaypoint : AbstractWaypoint
{
    private AbstractWaypoint _waypoint;
    private NavMeshAgent _mesh;

    [SerializeField] private GameObject _nextPoint;
    
    private void Start()
    {
        _mesh = GetComponent<NavMeshAgent>();
        
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Next();
        }
    }

    private void Next()
    {
        _mesh.SetDestination(_nextPoint.transform.position);
        Destroy(this);
    }
}
