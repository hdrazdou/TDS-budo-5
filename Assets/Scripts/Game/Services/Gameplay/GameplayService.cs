using TDS.Game.Services.LevelManagement;
using TDS.Game.Services.Missions;
using TDS.Infrastructure.Locator;
using TDS.Infrastructure.State;
using UnityEngine;

namespace TDS.Game.Services.Gameplay
{
    public class GameplayService : IService
    {
        #region Variables

        private readonly LevelManagementService _levelManagementService;
        private readonly MissionGameService _missionGameService;
        private readonly StateMachine _stateMachine;

        #endregion

        #region Setup/Teardown

        public GameplayService(MissionGameService missionGameService, LevelManagementService levelManagementService,
            StateMachine stateMachine)
        {
            _missionGameService = missionGameService;
            _levelManagementService = levelManagementService;
            _stateMachine = stateMachine;
        }

        #endregion

        #region Public methods

        public void Dispose()
        {
            _missionGameService.OnCompleted -= OnMissionCompleted;
        }

        public void Initialize()
        {
            _missionGameService.OnCompleted += OnMissionCompleted;
        }

        #endregion

        #region Private methods

        private void OnMissionCompleted()
        {
            _levelManagementService.IncrementLevel();

            if (_levelManagementService.IsCurrentLevelExisting())
            {
                _stateMachine.Enter<GameState>();
            }
            else
            {
                Debug.Log("YOU WON");
            }
        }

        #endregion
    }
}