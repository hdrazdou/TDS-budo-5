using TDS.Game.Player;
using TDS.Game.Services.Coroutine;
using TDS.Infrastructure.Locator;
using TDS.Infrastructure.State;
using TDS.Utility;
using UnityEngine;

namespace TDS.Game.Services
{
    
    public class LevelService : IService
    {
        #region Variables

        private readonly CoroutineRunner _coroutineRunner;

        [Header("Settings")]
        private const int _reloadDelay = 2;
        private readonly StateMachine _stateMachine;

        private PlayerDeath _playerDeath;

        #endregion

        #region Setup/Teardown

        public LevelService(StateMachine stateMachine, CoroutineRunner coroutineRunner)
        {
            _stateMachine = stateMachine;
            _coroutineRunner = coroutineRunner;
        }

        #endregion

        #region Public methods

        public void Dispose()
        {
            _playerDeath.OnHappened -= ReloadLevel;
            _playerDeath = null;
        }

        public void Initialize(PlayerDeath playerDeath)
        {
            Debug.Log("LevelService Initialize");

            _playerDeath = playerDeath;
            _playerDeath.OnHappened += ReloadLevel;
        }

        #endregion

        #region Private methods

        private void EnterState()
        {
            _stateMachine.Enter<GameState>();
        }

        private void ReloadLevel()
        {
            _coroutineRunner.StartTimer(_reloadDelay, EnterState);
        }

        #endregion
    }
}