using UnityEngine;

namespace TDS.Game.Enemy
{
    internal class EnemyStand : EnemyDefaultBehaviour
    {
        #region Variables

        [SerializeField] private EnemyMovement _movement;
        [SerializeField] private bool _needReturnToStartPosition = true;

        private Transform _startPositionTransform;

        #endregion

        #region Unity lifecycle

        protected override void Awake()
        {
            base.Awake();

            _startPositionTransform = new GameObject("Start Position").transform;
            _startPositionTransform.position = transform.position;
        }

        private void OnEnable()
        {
            if (_needReturnToStartPosition)
            {
                _movement.SetTarget(_startPositionTransform);
            }
        }

        #endregion
    }
}