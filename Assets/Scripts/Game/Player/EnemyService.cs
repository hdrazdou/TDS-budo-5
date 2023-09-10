using System;
using UnityEngine;

namespace TDS.Game.Player
{
    public class EnemyService : MonoBehaviour
    {
        #region Variables

        private int _hp;

        #endregion

        #region Events

        public event Action OnEnemyDied;

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
                    OnEnemyDied?.Invoke();
                }
            }
        }

        #endregion
    }
}