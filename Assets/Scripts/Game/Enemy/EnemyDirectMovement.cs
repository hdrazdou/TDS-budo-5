using UnityEngine;

namespace TDS.Game.Enemy
{
    public class EnemyDirectMovement : EnemyMovement
    {
        #region Variables

        [SerializeField] private Rigidbody2D _rb;
        [SerializeField] private float _speed = 3f;
        private bool _isMovingToPoint;
        private Vector3 _pointPosition;

        private Transform _target;

        #endregion

        #region Unity lifecycle

        private void Update()
        {
            if (_isMovingToPoint)
            {
                MoveToPoint(_pointPosition);
                return;
            }

            if (_target == null)
            {
                return;
            }

            MoveToTarget();
        }

        private void OnDisable()
        {
            _rb.velocity = Vector2.zero;
        }

        #endregion

        #region Public methods

        public override void GoToPoint(Vector3 pointPosition)
        {
            _pointPosition = pointPosition;
            _isMovingToPoint = true;
        }

        public override void SetTarget(Transform target)
        {
            _target = target;

            if (_target == null)
            {
                _rb.velocity = Vector2.zero;
            }
        }

        #endregion

        #region Private methods

        private void MoveToPoint(Vector3 pointPosition)
        {
            Vector3 direction = (pointPosition - transform.position).normalized;
            _rb.velocity = direction * _speed;
            transform.up = direction;

            float distanceToSpawnSpot = Vector3.Distance(transform.position, pointPosition);

            if (distanceToSpawnSpot < 1f)
            {
                _isMovingToPoint = false;
                SetTarget(null);
            }
        }

        private void MoveToTarget()
        {
            Vector3 direction = (_target.position - transform.position).normalized;
            _rb.velocity = direction * _speed;
            transform.up = direction;
        }

        #endregion
    }
}