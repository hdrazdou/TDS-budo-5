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