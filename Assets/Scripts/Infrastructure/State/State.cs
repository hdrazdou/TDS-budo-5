namespace TDS.Infrastructure.State
{
    public abstract class State : IState
    {
        #region IState

        public abstract void Exit();

        public abstract void Enter();

        #endregion
    }
}