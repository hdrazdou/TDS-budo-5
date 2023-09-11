using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace TDS.Game.Services
{
    public class SceneLoader : MonoBehaviour
    {
        #region Public methods

        public IEnumerator ReloadScene()
        {
            yield return new WaitForSeconds(2f);

            Scene currentScene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(currentScene.name);
        }

        #endregion
    }
}