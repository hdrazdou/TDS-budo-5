using TDS.Game.Player;
using TDS.Game.Services;
using TDS.Game.Services.Coroutine;
using TDS.Game.Services.Gameplay;
using TDS.Game.Services.Input;
using TDS.Game.Services.LevelManagement;
using TDS.Game.Services.Missions;
using TDS.Infrastructure.Locator;
using TDS.Utility;
using UnityEngine;

namespace TDS.Infrastructure.State
{
    public class GameState : AppState
    {
        #region Variables

        private PlayerMovement _playerMovement;
        private PlayerDeath _playerDeath;

        #endregion

        #region Setup/Teardown

        public GameState(ServiceLocator serviceLocator) : base(serviceLocator) { }

        #endregion

        #region Public methods

        public override void Enter()
        {
            LevelManagementService levelManagementService = ServiceLocator.Get<LevelManagementService>();
            levelManagementService.Initialize();
            levelManagementService.LoadCurrentLevel();

            ServiceLocator.Get<CoroutineRunner>().StartFrameTimer(1, InitAfterLoadScene);
        }

        public override void Exit()
        {
            _playerMovement.Dispose();

            ServiceLocator.Get<MissionGameService>().Dispose();
            ServiceLocator.Get<GameplayService>().Dispose();
            ServiceLocator.Get<IInputService>().Dispose();
            ServiceLocator.Get<LevelService>().Dispose();
        }

        #endregion

        #region Private methods

        private void InitAfterLoadScene()
        {
            ServiceLocator.Get<MissionGameService>().Initialize();
            ServiceLocator.Get<GameplayService>().Initialize();
            
            _playerDeath = Object.FindObjectOfType<PlayerDeath>();
            ServiceLocator.Get<LevelService>().Initialize(_playerDeath);

            _playerMovement = Object.FindObjectOfType<PlayerMovement>();
            Transform playerMovementTransform = _playerMovement.transform;

            IInputService inputService = ServiceLocator.Get<IInputService>();
            inputService.Initialize(Camera.main, playerMovementTransform);

            _playerMovement.Construct(inputService);
        }

        #endregion
    }
}