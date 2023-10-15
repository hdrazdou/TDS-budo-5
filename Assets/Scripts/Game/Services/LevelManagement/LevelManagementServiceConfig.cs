using UnityEngine;

namespace TDS.Game.Services.LevelManagement
{
    [CreateAssetMenu(fileName = nameof(LevelManagementServiceConfig), menuName = "TDS/Game/Level Management Config")]
    public class LevelManagementServiceConfig : ScriptableObject
    {
        #region Variables

        [SerializeField] private string[] _sceneNames;

        #endregion

        #region Properties

        public string[] SceneNames => _sceneNames;

        #endregion
    }
}