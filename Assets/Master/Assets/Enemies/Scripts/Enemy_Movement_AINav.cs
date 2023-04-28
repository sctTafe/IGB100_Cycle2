using UnityEngine;
using UnityEngine.AI;

public class Enemy_Movement_AINav : MonoBehaviour
{
    [SerializeField] private LayerMask _groundLayer;    
    [SerializeField] private float _drunkWalkRange;     

    private NavMeshAgent _agent;
    private Transform _TargetTransfrom;  
    private bool _isWalkPointSet;
    private Vector3 _walkPoint;


    #region Unity Functions
    private void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
    }
    private void Update()
    {      
        if (_TargetTransfrom != null)
            UpdateAINavDestinationWithTargetPosition();
        else
            DrunkWalk();                 
    }
    #endregion

    #region Public Functions
    public void fn_SetTargetTransfrom(Transform target) => _TargetTransfrom = target;
    #endregion

    #region Priavte Functions
    private void UpdateAINavDestinationWithTargetPosition() => _agent.SetDestination(_TargetTransfrom.position);
    private void DrunkWalk()
    {
        if (!_isWalkPointSet) DrunkWalk_CalculateNewWalkPoint();
        if (_isWalkPointSet) _agent.SetDestination(_walkPoint);

        Vector3 distanceToWalkPoint = transform.position - _walkPoint;
        //walk point reached, find new walk point
        if (distanceToWalkPoint.magnitude < 1f)
            _isWalkPointSet = false;
    }
    private void DrunkWalk_CalculateNewWalkPoint()
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
    #endregion

}
