namespace TDS.Game.Enemy
{
    public abstract class EnemyDefaultBehaviour : EnemyComponent
    {
        #region Unity lifecycle

        private void Awake()
        {
            Activate();
        }

        #endregion
    }
}