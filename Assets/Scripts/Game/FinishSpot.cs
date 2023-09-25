using TDS.Game.Services;
using UnityEngine;

namespace TDS.Game
{
    public class FinishSpot : MonoBehaviour
    {
        [Header("Settings")]
        [SerializeField] private int _loadDelay;
        
        [Header("Components")]
        [SerializeField] private SceneLoader _sceneLoader;

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag(Tags.Player))
            {
                _sceneLoader.LoadNextScene(_loadDelay);
            }
        }
    }
}