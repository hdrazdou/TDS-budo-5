using UnityEngine;

namespace TDS.Game.Enemy
{
    public class EnemyAnimation : MonoBehaviour
    {
        #region Variables

        private static readonly int Attack = Animator.StringToHash("Attack");

        private static readonly int Death = Animator.StringToHash("Death");
        [SerializeField] private Animator _animator;

        #endregion

        #region Public methods

        public void PlayAttack()
        {
            _animator.SetTrigger(Attack);
            Debug.Log("EnemyAnimation PlayAttack");
        }

        public void PlayDeath()
        {
            _animator.SetTrigger(Death);
        }

        #endregion
    }
}