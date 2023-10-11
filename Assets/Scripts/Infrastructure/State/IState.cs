namespace TDS.Infrastructure.State
{
    public interface IState : IExitableState
    {
        #region Public methods

        void Enter();

        #endregion
    }
}