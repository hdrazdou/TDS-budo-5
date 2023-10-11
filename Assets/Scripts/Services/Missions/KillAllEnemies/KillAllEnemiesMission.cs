using System.Collections.Generic;
using System.Linq;
using TDS.Game.Enemy;
using UnityEngine;

namespace TDS.Services.Missions
{
    public class KillAllEnemiesMission : BaseMission<KillAllEnemiesMissionCondition>
    {
        #region Variables

        private List<EnemyDeath> _enemyDeaths;

        #endregion

        #region Protected methods

        protected override void OnDispose()
        {
            base.OnDispose();

            foreach (EnemyDeath enemyDeath in _enemyDeaths)
            {
                enemyDeath.OnHappened -= OnEnemyDead;
            }

            _enemyDeaths.Clear();
        }

        protected override void OnInitialize()
        {
            base.OnInitialize();

            _enemyDeaths = Object.FindObjectsOfType<EnemyDeath>().ToList();

            foreach (EnemyDeath enemyDeath in _enemyDeaths)
            {
                enemyDeath.OnHappened += OnEnemyDead;
            }
        }

        #endregion

        #region Private methods

        private void OnEnemyDead(EnemyDeath enemyDeath)
        {
            enemyDeath.OnHappened -= OnEnemyDead;
            _enemyDeaths.Remove(enemyDeath);

            if (_enemyDeaths.Count == 0)
            {
                InvokeCompletion();
            }
        }

        #endregion
    }
}