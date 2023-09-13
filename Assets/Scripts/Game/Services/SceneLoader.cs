using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace TDS.Game.Services
{
    public class SceneLoader : MonoBehaviour
    {
        #region Public methods

        public void ReloadScene(int delay)
        {
            StartCoroutine(ReloadSceneInternal(delay));
        }

        #endregion

        #region Private methods

        private IEnumerator ReloadSceneInternal(int delay)
        {
            yield return new WaitForSeconds(delay);

            Scene currentScene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(currentScene.name);
        }

        #endregion
    }
}