using System;
using UnityEngine;

namespace TDS.Game
{
    public class UnitHp : MonoBehaviour
    {
        #region Variables

        [SerializeField] private int _initHp = 3;
        [SerializeField] private int _maxHp = 3;
        private int _current;

        #endregion

        #region Events

        public event Action<int> OnChanged;

        #endregion

        #region Properties

        public int Current
        {
            get => _current;
            private set
            {
                bool needChange = _current != value;

                if (needChange)
                {
                    _current = value;
                    OnChanged?.Invoke(_current);
                }
            }
        }

        #endregion

        #region Unity lifecycle

        private void Awake()
        {
            Current = _initHp;
        }

        #endregion

        #region Public methods

        public void Change(int value)
        {
            Current = Math.Clamp(Current + value, 0, _maxHp);
        }

        #endregion
    }
}