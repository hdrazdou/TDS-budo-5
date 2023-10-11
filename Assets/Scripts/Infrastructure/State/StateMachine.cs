using System;
using TDS.Infrastructure.Locator;

namespace TDS.Infrastructure.State
{
    public class StateMachine : IService
    {
        #region Variables

        private IExitableState _currentState;

        #endregion

        #region Public methods

        public void Enter<T>() where T : class, IState
        {
            _currentState?.Exit();
            T newState = Create<T>();
            _currentState = newState;
            newState.Enter();
        }

        #endregion

        #region Private methods

        private T Create<T>() where T : class, IExitableState
        {
            return Activator.CreateInstance(typeof(T), args: ServiceLocator.Instance) as T;
        }

        #endregion
    }
}