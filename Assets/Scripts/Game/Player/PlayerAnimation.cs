using UnityEngine;

namespace TDS.Game.Player
{
    public class PlayerAnimation : MonoBehaviour
    {
        #region Variables

        private static readonly int Attack = Animator.StringToHash("Attack");
        private static readonly int Death = Animator.StringToHash("Death");
        private static readonly int Speed = Animator.StringToHash("Speed");
        [SerializeField] private Animator _animator;

        private GameService _gameService;

        #endregion

        #region Unity lifecycle

        private void Start()
        {
            _gameService = FindObjectOfType<GameService>();
            _gameService.OnUserDied += PlayDeath;
        }

        #endregion

        #region Public methods

        public void PlayAttack()
        {
            _animator.SetTrigger(Attack);
        }

        public void PlayDeath()
        {
            _animator.SetTrigger(Death);
        }

        public void SetSpeed(float value)
        {
            _animator.SetFloat(Speed, value);
        }

        #endregion
    }
}