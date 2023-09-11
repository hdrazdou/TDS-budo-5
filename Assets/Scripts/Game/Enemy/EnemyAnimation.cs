using UnityEngine;

namespace TDS.Game.Enemy
{
    public class EnemyAnimation : MonoBehaviour
    {
        #region Variables

        private static readonly int Death = Animator.StringToHash("Death");

        public EnemyHpService _enemyHpService;

        [SerializeField] private Animator _animator;

        #endregion

        #region Unity lifecycle

        private void Start()
        {
            _enemyHpService = GetComponent<EnemyHpService>();
            _enemyHpService.OnEnemyDied += PlayDeath;
        }

        private void OnDestroy()
        {
            _enemyHpService.OnEnemyDied -= PlayDeath;
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