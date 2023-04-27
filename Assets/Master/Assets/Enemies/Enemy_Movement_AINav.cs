using UnityEngine;
using UnityEngine.AI;

public class Enemy_Movement_AINav : MonoBehaviour
{
    [SerializeField] private LayerMask _groundLayer, _playerLayer;    
    [SerializeField] private float _drunkWalkRange;     
    [SerializeField] private float _playerSightRange;

    private NavMeshAgent _agent;
    private Transform _player;  
    private bool _isWalkPointSet;
    private Vector3 _walkPoint;

    private void Start()
    {
        _player = GameObject.Find("Player").transform;
        _agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        bool playerInSightRange = Physics.CheckSphere(transform.position, _playerSightRange, _playerLayer);

        if (playerInSightRange)
            ChasePlayer();
        else
            Patroling();                 
    }

    private void Patroling()
    {
        if (!_isWalkPointSet) CalculateNewWalkPoint();
        if (_isWalkPointSet) _agent.SetDestination(_walkPoint);

        Vector3 distanceToWalkPoint = transform.position - _walkPoint;
        //walk point reached, find new walk point
        if (distanceToWalkPoint.magnitude < 1f)
            _isWalkPointSet = false;
    }

    private void ChasePlayer() => _agent.SetDestination(_player.position);

    private void CalculateNewWalkPoint()
    {
        //calculates a random point in range
        float randomZ = Random.Range(-_drunkWalkRange, _drunkWalkRange);
        float randomX = Random.Range(-_drunkWalkRange, _drunkWalkRange);
        _walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);

        //checks if walk point is inside map
        // DOSE: creates a downward raycast at the 'new' walk point and checks if it hits ground
        if (Physics.Raycast(_walkPoint, -transform.up, 2f, _groundLayer))
            _isWalkPointSet = true;
    }


}
