using System;
using UnityEngine;

namespace TDS.Game.Player
{
    public class PlayerHp : MonoBehaviour
    {
        #region Variables

        [Header("Settings")]
        [SerializeField] private LayerMask _layerMask;
        [SerializeField] private int _initHp = 3;
        [SerializeField] private int _maxHp = 10;

        [Header("Components")]
        private int _hp = 3;

        #endregion

        #region Events

        public event Action<int> OnChanged;

        #endregion

        #region Properties

        public int Hp
        {
            get => _hp;
            set
            {
                int newValue = Math.Clamp(value, 0, _maxHp);
                bool needNotify = _hp != newValue;
                _hp = newValue;

                if (needNotify)
                {
                    OnChanged?.Invoke(_hp);
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
            Hp--;
        }

        #endregion

        #region Private methods

        private void SetInitValues()
        {
            Hp = _initHp;
        }

        #endregion
    }
}