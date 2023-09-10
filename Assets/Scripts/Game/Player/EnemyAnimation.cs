using UnityEngine;

namespace TDS.Game.Player
{
    public class EnemyAnimation : MonoBehaviour
    {
        #region Variables

        private static readonly int Death = Animator.StringToHash("Death");

        [SerializeField] private Animator _animator;

        private EnemyService _enemyService;

        #endregion

        #region Unity lifecycle

        private void Start()
        {
            _enemyService = FindObjectOfType<EnemyService>();
            _enemyService.OnEnemyDied += PlayDeath;
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