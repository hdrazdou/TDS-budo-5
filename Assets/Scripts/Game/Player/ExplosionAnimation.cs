using UnityEngine;

namespace TDS.Game.Player
{
    public class ExplosionAnimation : MonoBehaviour
    {
        #region Variables

        private static readonly int Explode = Animator.StringToHash("Explode");

        [SerializeField] private Animator _animator;

        #endregion

        #region Public methods

        public void PlayExplosion()
        {
            _animator.SetTrigger(Explode);
        }

        #endregion
    }
}