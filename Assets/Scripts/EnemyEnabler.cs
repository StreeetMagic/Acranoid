using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace Enemy
{
    [RequireComponent(typeof(Spawner))]
    public class EnemyEnabler : MonoBehaviour
    {
        [field: SerializeField] public int EnemiesAvaliable { get; private set; } = 1;
        [field: SerializeField] public int NewEnemyCooldown { get; private set; } = 30;

        private Spawner _spawner;


        private void Start()
        {
            _spawner = GetComponent<Spawner>();
            StartCoroutine(NewEnemiesTimer());
        }

        private IEnumerator NewEnemiesTimer()
        {
            int enemyCount = _spawner.EnemyCount;
            WaitForSeconds cooldown = new WaitForSeconds(NewEnemyCooldown);
            yield return cooldown;

            while (EnemiesAvaliable < enemyCount)
            {
                EnemiesAvaliable++;
                yield return cooldown;
            }
        }
    }
}
