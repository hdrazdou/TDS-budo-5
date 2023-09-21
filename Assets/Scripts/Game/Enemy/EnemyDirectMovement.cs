using UnityEngine;

namespace TDS.Game.Enemy
{
    public class EnemyDirectMovement : EnemyMovement
    {
        #region Variables

        [SerializeField] private Rigidbody2D _rb;
        [SerializeField] private EnemyAnimation _animation;
        [SerializeField] private float _speed = 3f;

        private Vector3 _pointPosition;
        private Transform _target;

        #endregion

        #region Unity lifecycle

        private void Update()
        {
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

        private void CheckDistance()
        {
            float distanceToSpawnSpot = Vector3.Distance(transform.position, _target.position);

            if (distanceToSpawnSpot < 1f)
            {
                SetTarget(null);
            }
        }

        private void MoveToTarget()
        {
            Vector3 direction = (_target.position - transform.position).normalized;
            _rb.velocity = direction * _speed;
            transform.up = direction;

            CheckDistance();

            _animation.SetSpeed(_rb.velocity.magnitude);
        }

        #endregion
    }
}