using System;
using UnityEngine;

namespace TDS.Game.Player
{
    public class PlayerDeath : MonoBehaviour
    {
        #region Variables

        [Header("Components")]
        [SerializeField] private UnitHp _hp;
        [SerializeField] private PlayerAnimation _animation;
        [SerializeField] private Collider2D _collider2D;
        [SerializeField] private PlayerMovement _playerMovement;
        [SerializeField] private PlayerAttack _playerAttack;

        private bool _isUserDead;

        #endregion

        #region Events

        public event Action OnHappened;

        #endregion

        #region Properties

        public bool IsUserDead
        {
            get => _isUserDead;
            private set
            {
                _isUserDead = value;

                if (_isUserDead)
                {
                    OnHappened?.Invoke();
                }
            }
        }

        #endregion

        #region Unity lifecycle

        private void OnEnable()
        {
            _hp.OnChanged += OnHpChanged;
        }

        private void OnDisable()
        {
            _hp.OnChanged -= OnHpChanged;
        }

        #endregion

        #region Private methods

        private void Die()
        {
            IsUserDead = true;
            _animation.PlayDeath();

            _collider2D.enabled = false;
            _playerAttack.enabled = false;
            _playerMovement.enabled = false;
        }

        private void OnHpChanged(int hp)
        {
            if (hp <= 0 && !IsUserDead)
            {
                Die();
            }
        }

        #endregion
    }
}