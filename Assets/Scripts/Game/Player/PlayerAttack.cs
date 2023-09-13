using UnityEngine;

namespace TDS.Game.Player
{
    public class PlayerAttack : MonoBehaviour
    {
        #region Variables

        [Header("Settings")]
        [SerializeField] private PlayerAnimation _animation;

        [Header("Components")]
        [SerializeField] private GameObject _bulletPrefab;
        [SerializeField] private Transform _bulletSpawnSpot;

        private PlayerHp _playerHp;

        #endregion

        #region Unity lifecycle

        private void Start()
        {
            _playerHp = GetComponent<PlayerHp>();
        }

        private void Update()
        {
            if (Input.GetButtonDown("Fire1"))
            {
                Fire();
            }
        }

        #endregion

        #region Private methods

        private void CreateBullet()
        {
            Instantiate(_bulletPrefab, _bulletSpawnSpot.position, transform.rotation);
        }

        private void Fire()
        {
            _animation.PlayAttack();
            CreateBullet();
        }

        #endregion
    }
}