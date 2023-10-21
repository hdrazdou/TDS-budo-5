using UnityEngine;

namespace TDS.Game.Services.Input
{
    public class StandAloneInputService : IInputService
    {
        #region Variables

        private Camera _camera;
        private Transform _playerMovementTransform;

        #endregion

        #region Properties

        public Vector2 Axes => new(UnityEngine.Input.GetAxis("Horizontal"), UnityEngine.Input.GetAxis("Vertical"));
        public Vector3 LookDirection => GetLookDirection();

        #endregion

        #region Public methods

        public void Dispose()
        {
            Debug.Log($"StandAloneInputService Dispose");
            
            _camera = null;
            _playerMovementTransform = null;
        }

        public void Initialize(Camera camera, Transform playerMovementTransform)
        {
            Debug.Log($"StandAloneInputService Initialize");

            _camera = camera;
            _playerMovementTransform = playerMovementTransform;
        }

        #endregion

        #region Private methods

        private Vector3 GetLookDirection()
        {
            Vector3 worldMousePosition = _camera.ScreenToWorldPoint(UnityEngine.Input.mousePosition);
            worldMousePosition.z = 0;
            Debug.Log($"StandAloneInputService GetLookDirection");
            return worldMousePosition - _playerMovementTransform.position;
            
            

        }

        #endregion
    }
}