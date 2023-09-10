using System;
using UnityEngine;

namespace TDS.Game.Player
{
    public class GameService : MonoBehaviour
    {
        #region Variables

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
                }
            }
        }

        #endregion

        #region Unity lifecycle

        private void Start()
        {
            isUserDead = false;
        }

        #endregion
    }
}