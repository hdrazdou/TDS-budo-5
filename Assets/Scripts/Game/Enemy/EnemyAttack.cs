using System.Collections;
using TDS.Game.Player;
using UnityEngine;

namespace TDS.Game.Enemy
{
    public class EnemyAttack : MonoBehaviour
    {
        #region Variables

        [Header("Components")]
        [SerializeField] private GameObject _bulletPrefab;
        [SerializeField] private Transform _bulletSpawnSpot;
        [SerializeField] private EnemyHp enemyHp;
        [SerializeField] private EnemyAnimation _animation;

        [Header("Settings")]
        [SerializeField] private float _attackDelay = 2;

        private PlayerDeath _playerDeath;
        private Transform _playerTransform;

        #endregion

        #region Unity lifecycle

        private void Start()
        {
            FindPlayer();
            Rotate();
            StartCoroutine(AttackCycle());
        }

        private void Update()
        {
            if (enemyHp.isEnemyDead)
            {
                return;
            }

            Rotate();
        }

        #endregion

        #region Private methods

        private void Attack()
        {
            Instantiate(_bulletPrefab, _bulletSpawnSpot.position, transform.rotation);
            _animation.PlayAttack();
        }

        private IEnumerator AttackCycle()
        {
            yield return new WaitForSeconds(_attackDelay);

            while (!_playerDeath.IsUserDead && !enemyHp.isEnemyDead)
            {
                Attack();
                yield return new WaitForSeconds(_attackDelay);
            }
        }

        private void FindPlayer()
        {
            _playerDeath = FindObjectOfType<PlayerDeath>();
            _playerTransform = _playerDeath.transform;
        }

        private void Rotate()
        {
            transform.up = _playerTransform.position - transform.position;
        }

        #endregion
    }
}