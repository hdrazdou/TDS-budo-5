using TDS.Game.Services.SceneLoading;
using TDS.Infrastructure.Locator;
using UnityEngine;

namespace TDS.Infrastructure.State
{
    public class MenuState : AppState
    {
        #region Setup/Teardown

        public MenuState(ServiceLocator serviceLocator) : base(serviceLocator) { }

        #endregion

        #region Public methods

        public override void Enter()
        {
            Debug.Log("MenuState Enter");

            ServiceLocator.Get<SceneLoadingService>().LoadScene(Scene.Menu);
        }

        public override void Exit()
        {
            Debug.Log("MenuState Exit");
        }

        #endregion
    }
}