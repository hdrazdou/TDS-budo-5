using UnityEngine;

namespace TDS.Game.Player
{
    public class EnemyAnimation : MonoBehaviour
    {
        #region Variables

        private static readonly int Death = Animator.StringToHash("Death");

        [SerializeField] private Animator _animator;

        private EnemyHpService _enemyHpService;

        #endregion

        #region Unity lifecycle

        private void Start()
        {
            _enemyHpService = FindObjectOfType<EnemyHpService>();
            _enemyHpService.OnEnemyDied += PlayDeath;
        }

        #endregion

        #region Public methods

        public void PlayDeath()
        {
            _animator.SetTrigger(Death);
        }

        #endregion
    }
}