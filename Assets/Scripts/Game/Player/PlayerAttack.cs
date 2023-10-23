using Lean.Pool;
using TDS.Game.Services.Input;
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

        private IInputService _inputService;

        #endregion

        #region Unity lifecycle

        private void OnEnable()
        {
            if (_inputService != null)
            {
                _inputService.OnAttack += Fire;
            }
        }

        private void OnDisable()
        {
            _inputService.OnAttack -= Fire;
        }

        #endregion

        #region Public methods

        public void Construct(IInputService inputService)
        {
            _inputService = inputService;
            _inputService.OnAttack += Fire;
        }

        #endregion

        #region Private methods

        private void CreateBullet()
        {
            LeanPool.Spawn(_bulletPrefab, _bulletSpawnSpot.position, transform.rotation);
        }

        private void Fire()
        {
            _animation.PlayAttack();
            CreateBullet();
        }

        #endregion
    }
}