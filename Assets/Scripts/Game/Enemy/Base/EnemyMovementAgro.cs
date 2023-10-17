using UnityEngine;

namespace TDS.Game.Enemy
{
    public class EnemyMovementAgro : EnemyComponent
    {
        #region Variables

        [Header("Components")]
        [SerializeField] private TriggerObserver _triggerObserver;
        [SerializeField] private EnemyMovement _enemyMovement;
        [SerializeField] private CircleCollider2D _movementAgroCollider;
        [SerializeField] private EnemyIdle _idle;

        [Header("Settings")]
        [SerializeField] private float _radius;
        [SerializeField] private LayerMask _obstaclesMask;

        private bool _isFollowing;

        private Vector3 _spawnSpot;

        #endregion

        #region Unity lifecycle

        private void Awake()
        {
            _spawnSpot = transform.position;
        }

        private void Start()
        {
            _movementAgroCollider.radius = _radius;
        }

        private void OnEnable()
        {
            _triggerObserver.OnExit += OnObserverExit;
            _triggerObserver.OnStay += OnObserverStay;
        }

        private void OnDisable()
        {
            _triggerObserver.OnExit -= OnObserverExit;
            _triggerObserver.OnStay -= OnObserverStay;
        }

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, _movementAgroCollider.radius);
        }

        #endregion

        #region Private methods

        private void OnObserverExit(Collider2D other)
        {
            _isFollowing = false;
            SetTarget(null);
        }

        private void OnObserverStay(Collider2D other)
        {
            if (_isFollowing)
            {
                return;
            }

            //TODO: visibility zone

            Vector3 direction = other.transform.position - transform.position;
            RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, direction.magnitude, _obstaclesMask);

            if (hit.transform != null)
            {
                return;
            }

            _isFollowing = true;
            SetTarget(other.transform);
        }

        private void SetTarget(Transform otherTransform)
        {
            if (_enemyMovement != null)
            {
                _enemyMovement.SetTarget(otherTransform);
            }

            if (_idle != null)
            {
                if (otherTransform == null)
                {
                    _idle.Activate();
                }
                else
                {
                    _idle.Deactivate();
                }
            }
        }

        #endregion
    }
}