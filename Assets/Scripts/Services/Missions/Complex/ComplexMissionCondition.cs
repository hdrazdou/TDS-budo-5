using UnityEngine;

namespace TDS.Services.Missions.Complex
{
    public class ComplexMissionCondition : MissionCondition
    {
        #region Variables

        [SerializeField] private MissionCondition[] _conditions;

        #endregion
    }
}