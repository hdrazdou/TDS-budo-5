using UnityEngine;

namespace TDS.Game.Enemy
{
    public class EnemyMovementAgro : EnemyComponent
    {
        #region Variables

        [SerializeField] private TriggerObserver _triggerObserver;
        [SerializeField] private EnemyMovement _enemyMovement;

        private Vector3 _spawnSpot;

        #endregion

        #region Unity lifecycle

        private void Awake()
        {
            _spawnSpot = transform.position;
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

        #endregion

        #region Private methods

        private void OnObserverEnter(Collider2D other)
        {
            SetTarget(other.transform);
        }

        private void OnObserverExit(Collider2D other)
        {
            SetTarget(null);
            ReturnToSpawnSpot();
        }

        private void ReturnToSpawnSpot()
        {
            if (_enemyMovement != null)
            {
                _enemyMovement.GoToPoint(_spawnSpot);
            }
        }

        private void SetTarget(Transform otherTransform)
        {
            if (_enemyMovement != null)
            {
                _enemyMovement.SetTarget(otherTransform);
            }
        }

        #endregion
    }
}