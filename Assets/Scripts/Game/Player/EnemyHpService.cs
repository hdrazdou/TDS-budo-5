using System;
using UnityEngine;

namespace TDS.Game.Player
{
    public class EnemyHpService : MonoBehaviour
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
            set
            {
                _hp = value;

                if (_hp <= 0)
                {
                    OnEnemyDied?.Invoke();
                }
            }
        }

        #endregion
    }
}