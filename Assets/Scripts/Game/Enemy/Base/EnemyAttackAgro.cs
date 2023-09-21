using UnityEngine;

namespace TDS.Game.Enemy
{
    public class EnemyAttackAgro : EnemyComponent
    {
        #region Variables

        [SerializeField] private TriggerObserver _triggerObserver;
        [SerializeField] private EnemyAttack _enemyAttack;
        [SerializeField] private EnemyMovement _enemyMovement;
        [SerializeField] private CircleCollider2D _attackAgroCollider;
        [SerializeField] private float _radius;

        #endregion

        #region Unity lifecycle

        private void Start()
        {
            _attackAgroCollider.radius = _radius;
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
            Gizmos.DrawWireSphere(transform.position, _attackAgroCollider.radius);
        }

        #endregion

        #region Private methods

        private void OnObserverEnter(Collider2D other)
        {
            SetActiveAttack(true);

            if (_enemyMovement != null)
            {
                _enemyMovement.Deactivate();
            }
        }

        private void OnObserverExit(Collider2D other)
        {
            SetActiveAttack(false);

            if (_enemyMovement != null)
            {
                _enemyMovement.Activate();
            }
        }

        private void SetActiveAttack(bool needAttack)
        {
            if (_enemyAttack != null)
            {
                if (needAttack)
                {
                    _enemyAttack.StartAttack();
                }
                else
                {
                    _enemyAttack.StopAttack();
                }
            }
        }

        #endregion
    }
}