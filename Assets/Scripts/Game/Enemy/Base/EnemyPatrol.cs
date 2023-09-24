using UnityEngine;

namespace TDS.Game.Enemy
{
    public class EnemyPatrol : EnemyIdle
    {
        #region Variables

        [SerializeField] private EnemyMovement _movement;
        [SerializeField] private PatrolPath _path;
        [SerializeField] private float _minDistance = 0.1f;

        private int _currentPointIndex;

        #endregion

        #region Unity lifecycle

        private void Update()
        {
            if (Vector3.Distance(_path.GetCurrentPoint().position, transform.position) <= _minDistance)
            {
                _path.SetNextPoint();
                _movement.SetTarget(_path.GetCurrentPoint());
            }
        }

        private void OnEnable()
        {
            _movement.SetTarget(_path.GetCurrentPoint());
        }

        #endregion
    }
}