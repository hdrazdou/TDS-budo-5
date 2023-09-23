using UnityEngine;

namespace TDS.Game.Enemy
{
    public abstract class EnemyAttack : EnemyComponent
    {
        #region Variables

        [Header(nameof(EnemyAttack))]
        [SerializeField] private float _attackDelay = 2f;

        private bool _needAttack;
        private float _nextAttackTime;

        #endregion

        #region Unity lifecycle

        private void Update()
        {
            if (!_needAttack)
            {
                return;
            }

            if (Time.time >= _nextAttackTime)
            {
                _nextAttackTime = Time.time + _attackDelay;
                OnPerformAttack();
            }
        }

        private void OnDisable()
        {
            StopAttack();
        }

        #endregion

        #region Public methods

        public void StartAttack()
        {
            _needAttack = true;
        }

        public void StopAttack()
        {
            _needAttack = false;
        }

        #endregion

        #region Protected methods

        protected virtual void OnPerformAttack() { }

        #endregion
    }
}