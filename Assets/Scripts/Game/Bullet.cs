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

        private void Start()
        {
            _rb.velocity = transform.up * _speed;
            this.StartTimer(_lifeTime, () => Destroy(gameObject));
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.TryGetComponent(out UnitHp unitHp))
            {
                unitHp.Change(-_damage);
            }

            Destroy(gameObject);
        }

        #endregion
    }
}