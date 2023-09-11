using System.Collections;
using TDS.Game.Player;
using UnityEngine;

namespace TDS.Game.Enemy
{
    public class EnemyAttack : MonoBehaviour
    {
        #region Variables

        // [Header("Settings")]
        // [SerializeField] private EnemyAnimation _animation;

        [Header("Components")]
        [SerializeField] private GameObject _bulletPrefab;
        [SerializeField] private Transform _bulletSpawnSpot;
        [SerializeField] private EnemyHpService _enemyHpService;

        [Header("Settings")]
        [SerializeField] private float _attackDelay = 2;

        private PlayerHpService _playerHpService;
        private Vector3 _playerPosition;
        private Transform _playerTransform;

        #endregion

        #region Unity lifecycle

        private void Start()
        {
            _enemyHpService = GetComponent<EnemyHpService>();

            FindPlayer();
            StartCoroutine(Attack());
        }

        private void Update()
        {
            if (_enemyHpService.isEnemyDead)
            {
                return;
            }

            Rotate();
        }

        #endregion

        #region Private methods

        private IEnumerator Attack()
        {
            while (!_playerHpService.isUserDead && !_enemyHpService.isEnemyDead)
            {
                yield return new WaitForSeconds(_attackDelay);
                Instantiate(_bulletPrefab, _bulletSpawnSpot.position, transform.rotation);
            }
        }

        private void FindPlayer()
        {
            _playerHpService = FindObjectOfType<PlayerHpService>();
            _playerTransform = _playerHpService.transform;
        }

        private void Rotate()
        {
            Vector3 playerPosition = _playerTransform.position;
            playerPosition.z = 0;

            Vector3 direction = playerPosition - transform.position;
            transform.up = direction;
        }

        #endregion
    }
}