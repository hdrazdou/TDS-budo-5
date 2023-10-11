using TDS.Infrastructure.Locator;
using TDS.Services.Coroutine;
using TDS.Services.Missions;
using TDS.Services.SceneLoading;
using TDS.Utility;
using UnityEngine;

namespace TDS.Infrastructure.State
{
    public class GameState : AppState
    {
        #region Setup/Teardown

        public GameState(ServiceLocator serviceLocator) : base(serviceLocator) { }

        #endregion

        #region Public methods

        public override void Enter()
        {
            Debug.Log($"GameState Enter '{Time.frameCount}'");

            ServiceLocator.Get<SceneLoadingService>().LoadScene(Scene.Game);

            ServiceLocator.Get<CoroutineRunner>().StartFrameTimer(1, InitAfterLoadScene);
        }

        public override void Exit()
        {
            Debug.Log("GameState Exit");

            ServiceLocator.Get<MissionGameService>().Dispose();
        }

        #endregion

        #region Private methods

        private void InitAfterLoadScene()
        {
            Debug.Log($"GameState InitAfterLoadScene '{Time.frameCount}'");

            ServiceLocator.Get<MissionGameService>().Initialize();
        }

        #endregion
    }
}