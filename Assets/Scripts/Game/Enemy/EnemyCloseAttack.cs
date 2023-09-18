using UnityEngine;

namespace TDS.Game.Enemy
{
    public class EnemyCloseAttack : EnemyAttack
    {
        #region Variables

        [Header(nameof(EnemyCloseAttack))]
        [SerializeField] private EnemyAnimation _enemyAnimation;
        [SerializeField] private int _damage = 1;

        private Transform _playerTransform;

        #endregion

        #region Unity lifecycle

        private void Start()
        {
            _playerTransform = GameObject.FindWithTag(Tags.Player).transform;
        }

        #endregion

        #region Protected methods

        protected override void OnPerformAttack()
        {
            base.OnPerformAttack();

            _enemyAnimation.PlayAttack();
            _playerTransform.TryGetComponent(out UnitHp unitHp);
            unitHp.Change(-_damage);
        }

        #endregion
    }
}