using Lean.Pool;
using TDS.Utility;
using UnityEngine;

namespace TDS.Game
{
    public class Bullet : MonoBehaviour
    {
        #region Variables

        [Header("Settings")]
        [SerializeField] private float _speed = 10f;
        [SerializeField] private float _lifeTime = 2f;
        [SerializeField] private int _damage = 1;

        [Header("Components")]
        [SerializeField] private Rigidbody2D _rb;

        #endregion

        #region Unity lifecycle

        private void OnEnable()
        {
            _rb.velocity = transform.up * _speed;
            this.StartTimer(_lifeTime, DestroyThis);
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.TryGetComponent(out UnitHp unitHp))
            {
                unitHp.Change(-_damage);
            }

            DestroyThis();
        }

        #endregion

        #region Private methods

        private void DestroyThis()
        {
            LeanPool.Despawn(gameObject);
        }

        #endregion
    }
}