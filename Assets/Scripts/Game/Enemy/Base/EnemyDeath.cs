using System;
using UnityEngine;

namespace TDS.Game.Enemy
{
    public class EnemyDeath : EnemyComponent
    {
        #region Variables

        [SerializeField] private UnitHp _hp;
        [SerializeField] private EnemyAnimation _animation;
        [SerializeField] private Collider2D _collider2D;
        [SerializeField] private EnemyAttack _enemyAttack;
        [SerializeField] private EnemyMovement _enemyMovement;
        [SerializeField] private EnemyMovementAgro _enemyMovementAgro;
        [SerializeField] private EnemyAttackAgro _enemyAttacktAgro;

        #endregion

        #region Events

        public event Action OnHappened;

        #endregion

        #region Properties

        public bool IsDead { get; private set; }

        #endregion

        #region Unity lifecycle

        private void OnEnable()
        {
            // OnHpChanged(_hp.Current); - сетает ноль и зомби сразу умирают
            // Debug.Log($"EnemyDeath OnEnable _hp.Current = {_hp.Current}");
            _hp.OnChanged += OnHpChanged;
        }

        private void OnDisable()
        {
            _hp.OnChanged -= OnHpChanged;
        }

        #endregion

        #region Private methods

        private void Die()
        {
            IsDead = true;
            OnHappened?.Invoke();
            _animation.PlayDeath();

            _collider2D.enabled = false;
            _enemyAttack.enabled = false;
            _enemyMovement.enabled = false;
            _enemyMovementAgro.enabled = false;
            _enemyAttacktAgro.enabled = false;
        }

        private void OnHpChanged(int currentHp)
        {
            if (IsDead || currentHp > 0)
            {
                return;
            }

            Die();
        }

        #endregion
    }
}