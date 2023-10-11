using TDS.Infrastructure.Locator;

namespace TDS.Infrastructure.State
{
    public abstract class AppState : IState
    {
        #region Properties

        public ServiceLocator ServiceLocator { get; }
        protected StateMachine StateMachine => ServiceLocator.Get<StateMachine>();

        #endregion

        #region Setup/Teardown

        protected AppState(ServiceLocator serviceLocator)
        {
            ServiceLocator = serviceLocator;
        }

        #endregion

        #region IState

        public abstract void Exit();

        public abstract void Enter();

        #endregion
    }
}