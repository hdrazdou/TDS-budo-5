using NaughtyAttributes;
using Pathfinding;
using UnityEngine;

namespace TDS.Game.Enemy
{
    public class AiPathMovement : EnemyMovement
    {
        #region Variables

        [ShowNonSerializedField]
        private AIDestinationSetter _aiDestinationSetter;

        [ShowNonSerializedField]
        private AIPath _aiPath;

        #endregion

        #region Unity lifecycle

        private void Start()
        {
            _aiPath = GetComponent<AIPath>();
            _aiDestinationSetter = GetComponent<AIDestinationSetter>();
        }

        #endregion

        #region Public methods

        public override void SetTarget(Transform target)
        {
            _aiDestinationSetter.target = target;
            bool isTargetValid = target != null;
            _aiPath.enabled = isTargetValid;
            Animation.SetSpeed(isTargetValid ? 1 : 0);
            
            Debug.Log($"AiPathMovement SetTarget target = {target}");
        }

        #endregion
    }
}