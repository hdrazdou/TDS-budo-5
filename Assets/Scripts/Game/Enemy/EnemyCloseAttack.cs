using UnityEngine;

namespace TDS.Game.Enemy
{
    public class EnemyCloseAttack : EnemyAttack
    {
        #region Variables

        [Header(nameof(EnemyCloseAttack))]
        [Header("Settings")]
        [SerializeField] private int _damage = 1;
        [SerializeField] private float detectRadius;
        [SerializeField] private LayerMask _playerMask;

        private Transform _playerTransform;

        #endregion

        #region Protected methods

        protected override void OnPerformAttack()
        {
            base.OnPerformAttack();

            Vector3 center = transform.position;
            Collider2D collider = Physics2D.OverlapCircle(center, detectRadius, _playerMask);
            collider.TryGetComponent(out UnitHp unitHp);
            unitHp.Change(-_damage);
        }

        #endregion
    }
}