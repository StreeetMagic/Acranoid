using System.Collections;
using UnityEngine;

namespace Scripts.Enemy.Spawner
{
    [RequireComponent(typeof(Spawner))]
    public class EnemyEnabler : MonoBehaviour
    {
        private Spawner _spawner;
        [field: SerializeField] public int EnemiesAvaliable { get; private set; } = 1;
        [field: SerializeField] public int NewEnemyCooldown { get; private set; } = 30;

        private void Start()
        {
            _spawner = GetComponent<Spawner>();
            StartCoroutine(NewEnemiesTimer());
        }

        private IEnumerator NewEnemiesTimer()
        {
            var enemyCount = _spawner.EnemyCount;
            var cooldown = new WaitForSeconds(NewEnemyCooldown);

            yield return cooldown;

            while (EnemiesAvaliable < enemyCount)
            {
                EnemiesAvaliable++;

                yield return cooldown;
            }
        }
    }
}