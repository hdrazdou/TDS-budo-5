using TDS.Game.Services.Input;
using UnityEngine;

namespace TDS.Game.Player
{
    public class PlayerMovement : MonoBehaviour
    {
        #region Variables

        [Header("Components")]
        [SerializeField] private PlayerAnimation _animation;
        [SerializeField] private Rigidbody2D _rb;

        [Header("Settings")]
        [SerializeField] private float _speed = 5f;

        private IInputService _inputService;

        #endregion

        #region Unity lifecycle

        private void Update()
        {
            if (_inputService == null)
            {
                return;
            }

            Rotate();
            Move();
        }

        #endregion

        #region Public methods

        public void Construct(IInputService inputService)
        {
            _inputService = inputService;
        }

        public void Dispose()
        {
            _inputService = null;
        }

        #endregion

        #region Private methods

        private void Move()
        {
            Vector2 velocity = _inputService.Axes * _speed;

            _rb.velocity = velocity;
            _animation.SetSpeed(velocity.magnitude);
        }

        private void Rotate()
        {
            transform.up = _inputService.LookDirection;
        }

        #endregion
    }
}