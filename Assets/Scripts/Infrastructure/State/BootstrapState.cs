using TDS.Game.Services.Gameplay;
using TDS.Game.Services.Input;
using TDS.Game.Services.LevelManagement;
using TDS.Infrastructure.Locator;
using TDS.Services.Coroutine;
using TDS.Services.Missions;
using TDS.Services.SceneLoading;
using UnityEngine;

namespace TDS.Infrastructure.State
{
    public class BootstrapState : AppState
    {
        #region Setup/Teardown

        public BootstrapState(ServiceLocator serviceLocator) : base(serviceLocator) { }

        #endregion

        #region Public methods

        public override void Enter()
        {
            Debug.Log("BootstrapState Enter");

            SceneLoadingService sceneLoadingService = new();
            ServiceLocator.Register(sceneLoadingService);
            MissionGameService missionGameService = new();
            ServiceLocator.Register(missionGameService);
            LevelManagementService levelManagementService = new(sceneLoadingService);
            ServiceLocator.Register(levelManagementService);
            ServiceLocator.RegisterMonobeh<CoroutineRunner>();
            ServiceLocator.Register(new GameplayService(missionGameService, levelManagementService, StateMachine));

#if UNITY_STANDALONE
            ServiceLocator.Register<IInputService>(new StandAloneInputService());
#elif UNITY_ANDROID || UNITY_IOS
            ServiceLocator.Register<IInputService>(new MobileInputSErvice());
#endif

            StateMachine.Enter<MenuState>();
        }

        public override void Exit()
        {
            Debug.Log("BootstrapState Exit");
        }

        #endregion
    }
}