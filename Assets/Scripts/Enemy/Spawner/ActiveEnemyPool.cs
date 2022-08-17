using System;
using UnityEngine;

namespace Scripts.Enemy.Spawner
{
    public class ActiveEnemyPool : MonoBehaviour
    {
        public event Action<Enemy> EnemyDied;

        public void GetEnemyTransform(Enemy enemy)
        {
            EnemyDied?.Invoke(enemy);
        }
    }
}