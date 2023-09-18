using System;
using UnityEngine;

namespace TDS.Game.Enemy
{
    public class EnemyPatroling : EnemyDirectMovement
    {
        #region Variables

        [Header("Settings")]
        [SerializeField] private bool _isPatroling;
        [SerializeField] private Vector3 _firstPoint;
        [SerializeField] private Vector3 _secondPoint;

        [Header("Components")]
        [SerializeField] private EnemyMovement _enemyMovement;

        #endregion

        #region Unity lifecycle

        private void Awake()
        {
            _firstPoint = transform.position;

            if (_isPatroling)
            {
                _enemyMovement.GoToPoint(_secondPoint);
            }
        }

        #endregion

        #region Public methods

        public override void GoToPoint(Vector3 point)
        {
            throw new NotImplementedException();
        }

        #endregion

        // private void Update()
        // {
        //     if (!_enemyMovement.isMovingToPoint)
        //     {
        //         _enemyMovement.GoToPoint(_firstPoint);
        //     }
        // }
    }
}