using System.Collections;
using UnityEngine;

namespace TDS.Game.Enemy
{
    public abstract class EnemyAttack : EnemyComponent
    {
        #region Variables

        [Header(nameof(EnemyAttack))]
        [SerializeField] private float _attackDelay = 2f;

        private IEnumerator _attackRoutine;
        private WaitForSeconds _wait;

        #endregion

        #region Unity lifecycle

        private void Awake()
        {
            _wait = new WaitForSeconds(_attackDelay);
        }

        private void OnDisable()
        {
            StopAttack();
        }

        #endregion

        #region Public methods

        public void StartAttack()
        {
            _attackRoutine = StartAttackInternal();
            StartCoroutine(_attackRoutine);
        }

        public void StopAttack()
        {
            if (_attackRoutine != null)
            {
                StopCoroutine(_attackRoutine);
                _attackRoutine = null;
            }
        }

        #endregion

        #region Protected methods

        protected virtual void OnPerformAttack() { }

        #endregion

        #region Private methods

        private IEnumerator StartAttackInternal()
        {
            while (true)
            {
                OnPerformAttack();
                yield return _wait;
            }
        }

        #endregion
    }
}