using UnityEngine;

namespace TDS.Game.Enemy
{
    public class EnemyRangeAttack : EnemyAttack
    {
        #region Variables

        [Header(nameof(EnemyRangeAttack))]
        [SerializeField] private Bullet _bulletPrefab;
        [SerializeField] private Transform _bulletSpawnSpot;
        [SerializeField] private EnemyAnimation _enemyAnimation;

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

            Vector3 direction = _playerTransform.position - transform.position;
            Instantiate(_bulletPrefab, _bulletSpawnSpot.position, transform.rotation);
        }

        #endregion
    }
}