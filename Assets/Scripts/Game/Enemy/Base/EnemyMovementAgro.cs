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
        [SerializeField] private EnemyDefaultBehaviour _defaultBehaviour;

        [Header("Settings")]
        [SerializeField] private float _radius;

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
            _triggerObserver.OnEnter += OnObserverEnter;
            _triggerObserver.OnExit += OnObserverExit;
        }

        private void OnDisable()
        {
            _triggerObserver.OnEnter -= OnObserverEnter;
            _triggerObserver.OnExit -= OnObserverExit;
        }

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, _movementAgroCollider.radius);
        }

        #endregion

        #region Private methods

        private void OnObserverEnter(Collider2D other)
        {
            SetTarget(other.transform);
        }

        private void OnObserverExit(Collider2D other)
        {
            SetTarget(null);
        }

        private void SetTarget(Transform otherTransform)
        {
            if (_enemyMovement != null)
            {
                _enemyMovement.SetTarget(otherTransform);
            }

            if (_defaultBehaviour != null)
            {
                if (otherTransform != null)
                {
                    _defaultBehaviour.Deactivate();
                }
                else
                {
                    _defaultBehaviour.Activate();
                }
            }
        }

        #endregion
    }
}