using UnityEngine;

namespace TDS.Game
{
    [RequireComponent(typeof(CircleCollider2D))]
    public class Tnt : MonoBehaviour
    {
        #region Variables

        private static readonly int Explosion = Animator.StringToHash("Explosion");

        [SerializeField] private float _explosionRadius;
        [SerializeField] private LayerMask _layerMask;
        [SerializeField] private int _damage;
        [SerializeField] private Collider2D _tntCollider;
        [SerializeField] private Animator _explosionAnimator;

        #endregion

        #region Unity lifecycle

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, _explosionRadius);
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            Explode();
        }

        #endregion

        #region Public methods

        public void PlayExplosion()
        {
            _explosionAnimator.SetTrigger(Explosion);
        }

        #endregion

        #region Private methods

        private void Explode()
        {
            PlayExplosion();

            Vector3 center = transform.position;
            Collider2D[] colliders = Physics2D.OverlapCircleAll(center, _explosionRadius, _layerMask);

            foreach (Collider2D collider in colliders)
            {
                if (collider.TryGetComponent(out UnitHp unitHp))
                {
                    unitHp.Change(-_damage);
                }
            }

            _tntCollider.enabled = false;
        }

        #endregion
    }
}