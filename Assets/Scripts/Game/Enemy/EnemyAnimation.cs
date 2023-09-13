using UnityEngine;

namespace TDS.Game.Enemy
{
    public class EnemyAnimation : MonoBehaviour
    {
        #region Variables

        private static readonly int Death = Animator.StringToHash("Death");
        private static readonly int IsUserAlive = Animator.StringToHash("IsUserAlive");

        [SerializeField] private Animator _animator;

        #endregion

        #region Public methods

        public void PlayAttack(bool isUserAlive)
        {
            _animator.SetBool(IsUserAlive, isUserAlive);
        }

        public void PlayDeath()
        {
            _animator.SetTrigger(Death);
        }

        #endregion
    }
}