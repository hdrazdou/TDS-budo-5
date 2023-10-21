using UnityEngine;

namespace TDS.Game.Enemy
{
    internal class EnemyIdleWithReturn : EnemyIdle
    {
        #region Variables

        [SerializeField] private EnemyMovement _enemyMovement;
        [SerializeField] private bool _needReturnToStartPosition = true;

        private Transform _startPositionTransform;

        #endregion

        #region Unity lifecycle

        private void Awake()
        {
            _startPositionTransform = new GameObject($"{gameObject.name} Start Point").transform;
            _startPositionTransform.position = transform.position;
        }

        private void Update()
        {
            if (Vector3.Distance(_startPositionTransform.position, transform.position) <= 1.6f)
            {
                _enemyMovement.SetTarget(null);
            }
        }

        private void OnEnable()
        {
            if (_needReturnToStartPosition)
            {
                _enemyMovement.SetTarget(_startPositionTransform);
            }
        }

        #endregion
    }
}