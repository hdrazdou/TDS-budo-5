using UnityEngine;

namespace TDS.Services.Missions
{
    public class MissionHolder : MonoBehaviour
    {
        #region Variables

        [SerializeField] private MissionCondition _missionCondition;

        #endregion

        #region Properties

        public MissionCondition MissionCondition => _missionCondition;

        #endregion
    }
}