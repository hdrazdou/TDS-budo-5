using TDS.Game.Player;
using UnityEngine;

namespace TDS.Game.Services
{
    public class LevelService : MonoBehaviour
    {
        #region Variables

        [Header("Components")]
        [SerializeField] private PlayerDeath _playerDeath;
        [SerializeField] private SceneLoader _sceneLoader;

        [Header("Settings")]
        [SerializeField] private int _reloadDelay = 2;

        #endregion

        #region Unity lifecycle

        private void Start()
        {
            _playerDeath.OnHappened += ReloadLevel;
        }

        private void OnDestroy()
        {
            _playerDeath.OnHappened -= ReloadLevel;
        }

        #endregion

        #region Private methods

        private void ReloadLevel()
        {
            _sceneLoader.ReloadScene(_reloadDelay);
        }

        #endregion
    }
}