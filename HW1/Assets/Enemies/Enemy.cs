using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    [SerializeField]private NavMeshAgent _agent;
    [SerializeField]private Transform _player;
    [SerializeField]private LayerMask _groundLayer, _playerLayer;
    [SerializeField]private GameObject _bullet;
    [SerializeField]private GameObject _barrel;
    [SerializeField]private float _upSpeed, _forwardSpeed;
    
    //Patroling
    [SerializeField]private Vector3 _walkPoint;
    [SerializeField]private bool _isWalkPointSet;
    [SerializeField]private float _walkPointRange;

    //Attacking
    [SerializeField]private float _timeBetweenAttacks;
    [SerializeField]private bool _alreadyAttacked;

    //States
    [SerializeField]private float _sightRange, _attackRange;
    [SerializeField]private bool _playerInSightRange, _playerInAttackRange;
    
    private void Awake() 
    {
        //"Player" is a name of player object
        _player = GameObject.Find("Tank Prefab").transform;
        _agent = GetComponent<NavMeshAgent>();
        // Physics.IgnoreLayerCollision(10, 9); // TODO: layer change (enemy's bullet)
    }
    private void Update()
    {
        //check for sight and attack range
        _playerInSightRange = Physics.CheckSphere(transform.position, _sightRange, _playerLayer);
        _playerInAttackRange = Physics.CheckSphere(transform.position, _attackRange, _playerLayer);
        
        if(!_playerInSightRange && !_playerInAttackRange)   Patroling();
        if(_playerInSightRange && !_playerInAttackRange)    ChasePlayer();
        if(_playerInAttackRange && _playerInSightRange)   AttackPlayer();
    }
    private void Patroling()
    {
        if(!_isWalkPointSet)    
            SearchWalkPoint();
        if(_isWalkPointSet)
            _agent.SetDestination(_walkPoint);
        
        Vector3 distanceToWalkPoint = transform.position - _walkPoint;
        //walkPoint reached
        if(distanceToWalkPoint.magnitude < 1.0f)
            _isWalkPointSet = false;
    }
    private void SearchWalkPoint()
    {
        //calculate random point in range
        float randomX = Random.Range(-_walkPointRange, _walkPointRange);
        float randomZ = Random.Range(-_walkPointRange, _walkPointRange);
        
        _walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);

        if(Physics.Raycast(_walkPoint, -transform.up, 2f, _groundLayer))
        {
            _isWalkPointSet = true;
        }
    }
    private void ChasePlayer()
    {
        _agent.SetDestination(_player.position);
    }
    private void AttackPlayer()
    {
        //Make sure enemy doesn't move
        _agent.SetDestination(transform.position);

        transform.LookAt(_player);

        if(!_alreadyAttacked)
        {
            ///Attack
            Rigidbody rb = Instantiate(_bullet, _barrel.transform.position, Quaternion.identity).GetComponent<Rigidbody>();
            // Physics.IgnoreCollision(rb.GetComponent<Collider>(), _barrel.GetComponent<Collider>());
            rb.AddForce(transform.forward * _forwardSpeed, ForceMode.Impulse);
            rb.AddForce(transform.up * _upSpeed, ForceMode.Impulse);
            ///
            _alreadyAttacked = true;
            Invoke(nameof(ResetAttack), _timeBetweenAttacks);
        }
    }
    private void ResetAttack()
    {
        _alreadyAttacked = false;
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, _attackRange);
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, _sightRange);
    }
}
