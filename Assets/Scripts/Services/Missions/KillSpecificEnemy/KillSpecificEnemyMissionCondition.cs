using System;
using TDS.Game.Enemy;
using UnityEngine;

namespace TDS.Services.Missions
{
    [Serializable]
    public class KillSpecificEnemyMissionCondition : MissionCondition
    {
        [SerializeField] private EnemyDeath _enemyDeath;

        public EnemyDeath EnemyDeath => _enemyDeath;
    }
}