using UnityEngine;

namespace TDS.Game.Enemy
{
    public abstract class EnemyMovement : EnemyComponent
    {
        #region Public methods

        public abstract void SetTarget(Transform target);
        public abstract void GoToPoint(Vector3 point);

        #endregion
    }
}