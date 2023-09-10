using System.Collections;
using UnityEngine;

namespace TDS.Game.Player
{
    public class EnemyAttack : MonoBehaviour
    {
        #region Variables

        // [Header("Settings")]
        // [SerializeField] private EnemyAnimation _animation;

        [Header("Components")]
        [SerializeField] private GameObject _bulletPrefab;
        [SerializeField] private Transform _bulletSpawnSpot;
        [SerializeField] private EnemyService _enemyService;

        [Header("Settings")]
        [SerializeField] private float _attackDelay = 2;

        private GameService _gameService;
        private Vector3 _playerPosition;
        private Transform _playerTransform;

        #endregion

        #region Unity lifecycle

        private void Start()
        {
            _gameService = FindObjectOfType<GameService>();
            _enemyService = FindObjectOfType<EnemyService>();

            FindPlayer();
            StartCoroutine(Attack());
        }

        private void Update()
        {
            Rotate();
        }

        #endregion

        #region Private methods

        private IEnumerator Attack()
        {
            while (!_gameService.isUserDead)
            {
                yield return new WaitForSeconds(_attackDelay);
                Instantiate(_bulletPrefab, _bulletSpawnSpot.position, transform.rotation);
                yield return new WaitForSeconds(_attackDelay);
                _enemyService.Hp = 0;
            }
        }

        private void FindPlayer()
        {
            PlayerAnimation playerAnimation = FindObjectOfType<PlayerAnimation>();
            _playerTransform = playerAnimation.transform;
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