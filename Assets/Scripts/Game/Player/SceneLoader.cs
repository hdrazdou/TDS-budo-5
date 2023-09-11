using System.Collections;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using Scene = UnityEngine.SceneManagement.Scene;

namespace TDS.Game.Player
{
    public class SceneLoader : MonoBehaviour
    {
        public IEnumerator ReloadScene()
        {
            yield return new WaitForSeconds(2f);
            
            Scene currentScene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(currentScene.name);
        }
    }
}