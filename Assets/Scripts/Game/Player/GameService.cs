using System;
using UnityEngine;

namespace TDS.Game.Player
{
    public class GameService : MonoBehaviour
    {
        #region Variables

        private bool _isUserDead;

        #endregion

        #region Events

        public event Action OnUserDied;

        #endregion

        #region Properties

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