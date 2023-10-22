using UnityEngine;

namespace TDS.Game.Enemy
{
    public class EnemyCloseAndRangeAttack : EnemyAttack
    {
        #region Variables

        [Header(nameof(EnemyCloseAndRangeAttack))]
        [SerializeField] private EnemyAttack _closeAttack;
        [SerializeField] private EnemyAttack _rangeAttack;

        [Header("Observer")]
        [SerializeField] private TriggerObserver _closeAttackTriggerObserver;

        private EnemyAttack _currentAttack;

        #endregion

        #region Unity lifecycle

        private void Awake()
        {
            SetCurrentAttack(true);
        }

        private void OnEnable()
        {
            _closeAttackTriggerObserver.OnEnter += OnCloseObserverEnter;
            _closeAttackTriggerObserver.OnExit += OnCloseObserverExit;
        }

        private void OnDisable()
        {
            _closeAttackTriggerObserver.OnEnter -= OnCloseObserverEnter;
            _closeAttackTriggerObserver.OnExit -= OnCloseObserverExit;
        }

        #endregion

        #region Protected methods

        protected override void OnPerformAttack()
        {
            base.OnPerformAttack();

            _currentAttack.PerformAttackForced();
        }

        #endregion

        #region Private methods

        private void OnCloseObserverEnter(Collider2D obj)
        {
            SetCurrentAttack(false);
            Debug.Log("EnemyCloseAndRangeAttack OnCloseObserverEnter");
        }

        private void OnCloseObserverExit(Collider2D obj)
        {
            SetCurrentAttack(true);
            Debug.Log("EnemyCloseAndRangeAttack OnCloseObserverExit");
        }

        private void SetCurrentAttack(bool isRange)
        {
            _currentAttack = isRange ? _rangeAttack : _closeAttack;
            Animation.SetAttackIndex(isRange ? 0 : 1);
        }

        #endregion
    }
}