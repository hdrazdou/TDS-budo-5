using UnityEngine;

namespace TDS.Game.Services.Missions.ReachDestination
{
    public class ReachDestinationMissionCondition : MissionCondition
    {
        #region Variables

        [SerializeField] private TriggerObserver _triggerObserver;

        #endregion

        #region Properties

        public TriggerObserver TriggerObserver => _triggerObserver;

        #endregion
    }
}