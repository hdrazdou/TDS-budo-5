using UnityEngine;

namespace TDS.Game.Enemy
{
    public abstract class EnemyMovement : EnemyComponent
    {
        #region Public methods

        public abstract void GoToPoint(Vector3 point);

        public abstract void SetTarget(Transform target);

        #endregion
    }
}