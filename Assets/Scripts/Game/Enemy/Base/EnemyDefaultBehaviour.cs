namespace TDS.Game.Enemy
{
    public abstract class EnemyDefaultBehaviour : EnemyComponent
    {
        #region Unity lifecycle

        protected virtual void Awake()
        {
            Activate();
        }

        #endregion
    }
}