using UnityEngine;

namespace TDS.Game.Enemy
{
    public abstract class EnemyMovement : EnemyComponent
    {
        #region Public methods

        public abstract void SetTarget(Transform target);

        #endregion
    }
}