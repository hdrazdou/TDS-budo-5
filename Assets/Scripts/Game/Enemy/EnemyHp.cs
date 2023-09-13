using System;
using UnityEngine;

namespace TDS.Game.Enemy
{
    public class EnemyHp : MonoBehaviour
    {
        #region Variables

        [Header("Settings")]
        [SerializeField] private int _initHp;
        [SerializeField] private LayerMask _layerMask;

        [Header("Components")]
        [SerializeField] private EnemyAnimation _animation;

        private int _hp;
        private bool _isEnemyDead;

        #endregion

        #region Events

        public event Action OnEnemyDied;

        #endregion

        #region Properties

        public int Hp
        {
            get => _hp;
            set
            {
                _hp = value;

                if (_hp <= 0)
                {
                    isEnemyDead = true;
                    _animation.PlayDeath();
                }
            }
        }

        public bool isEnemyDead
        {
            get => _isEnemyDead;
            set
            {
                _isEnemyDead = value;

                if (_isEnemyDead)
                {
                    OnEnemyDied?.Invoke();
                }
            }
        }

        #endregion

        #region Unity lifecycle

        private void Start()
        {
            SetInitValues();
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if ((_layerMask.value & (1 << other.gameObject.layer)) != 0)
            {
                Hp--;
            }
        }

        #endregion

        #region Private methods

        private void SetInitValues()
        {
            Hp = _initHp;
            isEnemyDead = false;
        }

        #endregion
    }
}