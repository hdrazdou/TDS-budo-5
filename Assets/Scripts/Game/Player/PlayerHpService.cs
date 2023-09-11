using System;
using UnityEngine;

namespace TDS.Game.Player
{
    public class PlayerHpService : MonoBehaviour
    {
        #region Variables

        [Header("Settings")]
        [SerializeField] private LayerMask _layerMask;
        [SerializeField] private int _initHp = 3;

        private int _hp = 3;
        private bool _isUserDead;

        #endregion

        #region Events

        public event Action OnHpChanged;

        public event Action OnUserDied;

        #endregion

        #region Properties

        public int Hp
        {
            get => _hp;
            private set
            {
                bool needNotify = _hp != value;
                _hp = value;

                if (needNotify)
                {
                    OnHpChanged?.Invoke();
                }

                if (_hp <= 0)
                {
                    isUserDead = true;
                }
            }
        }

        public bool isUserDead
        {
            get => _isUserDead;
            private set
            {
                _isUserDead = value;

                if (_isUserDead)
                {
                    OnUserDied?.Invoke();
                    RestartLevel();
                }
            }
        }

        private void RestartLevel()
        {
            SceneLoader sceneLoader = FindObjectOfType<SceneLoader>();
            StartCoroutine(sceneLoader.ReloadScene());
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
            isUserDead = false;
            Hp = _initHp;
        }

        #endregion
    }
}