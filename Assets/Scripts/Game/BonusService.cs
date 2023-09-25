using TDS.Game.Enemy;
using Unity.Mathematics;
using UnityEngine;

namespace TDS.Game
{
    public class BonusService : MonoBehaviour
    {
        #region Variables

        [SerializeField] private EnemyDeath _enemyDeath;
        [SerializeField] private HpBooster _hpBoosterPrefab;
        [Range(1, 101)]
        [SerializeField] private int _probability = 50;

        #endregion

        #region Unity lifecycle

        private void OnEnable()
        {
            _enemyDeath.OnHappened += CreateBonus;
        }

        private void OnDisable()
        {
            _enemyDeath.OnHappened -= CreateBonus;
        }

        #endregion

        #region Private methods

        private void CreateBonus()
        {
            int random = UnityEngine.Random.Range(1, 101);

            if (_probability < random)
            {
                Instantiate(_hpBoosterPrefab, transform.position, quaternion.identity);
            }
        }

        #endregion
    }
}