using UnityEngine;

namespace TDS.Game.Player
{
    public class PlayerMovement : MonoBehaviour
    {
        #region Variables

        [Header("Components")]
        [SerializeField] private PlayerAnimation _animation;

        [Header("Settings")]
        [SerializeField] private float _speed = 5f;

        #endregion

        #region Unity lifecycle

        private void Start() { }

        private void Update()
        {
            Rotate();
            Move();
        }

        #endregion

        #region Private methods

        private void Move()
        {
            Vector2 input = new(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
            Vector2 velocity = input * _speed;

            Vector3 currentPosition = transform.position;
            currentPosition.x += velocity.x * Time.deltaTime;
            currentPosition.y += velocity.y * Time.deltaTime;
            transform.position = currentPosition;

            _animation.SetSpeed(velocity.magnitude);
        }

        private void Rotate()
        {
            Vector3 worldMousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            worldMousePosition.z = 0;
            Vector3 direction = worldMousePosition - transform.position;
            transform.up = direction;
        }

        #endregion
    }
}