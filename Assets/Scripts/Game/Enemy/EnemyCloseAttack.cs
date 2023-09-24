using UnityEngine;

namespace TDS.Game.Enemy
{
    public class EnemyCloseAttack : EnemyAttack
    {
        #region Variables

        [Header(nameof(EnemyCloseAttack))]
        [Header("Settings")]
        [SerializeField] private Transform _hitTransform;

        [Header("Settings")]
        [SerializeField] private int _damage = 1;
        [SerializeField] private float _hitRadius;
        [SerializeField] private LayerMask _playerMask;

        #endregion

        #region Unity lifecycle

        private void OnEnable()
        {
            Animation.OnCloseAttackHit += OnCloseAttackHit;
        }

        private void OnDisable()
        {
            Animation.OnCloseAttackHit -= OnCloseAttackHit;
        }

        private void OnDrawGizmosSelected()
        {
            if (_hitTransform == null)
            {
                return;
            }

            Gizmos.color = Color.cyan;
            Gizmos.DrawWireSphere(_hitTransform.position, _hitRadius);
        }

        #endregion

        #region Private methods

        private void OnCloseAttackHit()
        {
            Collider2D[] colliders = Physics2D.OverlapCircleAll(_hitTransform.position, _hitRadius, _playerMask);

            foreach (Collider2D collider in colliders)
            {
                if (collider.TryGetComponent(out UnitHp hp))
                {
                    hp.Change(-_damage);
                }
            }
        }

        #endregion
    }
}