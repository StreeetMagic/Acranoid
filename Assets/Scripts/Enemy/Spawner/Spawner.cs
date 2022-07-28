using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace Enemy
{
    [RequireComponent(typeof(CooldownUpgrader))]
    [RequireComponent(typeof(EnemyEnabler))]
    public class Spawner : MonoBehaviour
    {
        [SerializeField] private Enemy[] _enemies;
        [SerializeField] private Transform[] _spawnPoints;
        [SerializeField] private GameObject _inactiveEnemyPool;
        [SerializeField] private ActiveEnemyPool _activeEnemyPool;
        [SerializeField] private Transform _activeBulletPool;
        [SerializeField] private CooldownUpgrader _cooldownUpgrader;
        [SerializeField] private EnemyEnabler _enemyEnabler;

        private List<List<Enemy>> _pools = new List<List<Enemy>>();

        [field: SerializeField] public float ElapsedTime { get; private set; } = 50;
        public int EnemyCount => _enemies.Length;

        private void Start()
        {
            _cooldownUpgrader = GetComponent<CooldownUpgrader>();
            _enemyEnabler = GetComponent<EnemyEnabler>();

            FillPools();
            Initialize();
            StartCoroutine(Spawning());
        }

        private IEnumerator Spawning()
        {
            bool gameIsOn = true;
            
            while (gameIsOn)
            {
                if (TryGetObject(out Enemy enemy))
                {
                    ElapsedTime = 0;
                    int spawnPointNumber = Random.Range(0, _spawnPoints.Length);
                    SetEnemy(enemy, _spawnPoints[spawnPointNumber].position);
                }

                yield return new WaitForSeconds(_cooldownUpgrader.CurrentSpawnCooldown);
            }
        }

        private void FillPools()
        {
            for (int i = 0; i < _enemies.Length; i++)
            {
                _pools.Add(new List<Enemy>());
            }
        }

        private void Initialize()
        {
            for (int i = 0; i < _enemies.Length; i++)
            {
                for (int j = 0; j < _enemies[i].MaxCount; j++)
                {
                    Enemy spawned = Instantiate(_enemies[i], _inactiveEnemyPool.transform);
                    spawned.SetActiveBulletPool(_activeBulletPool);
                    spawned.gameObject.SetActive(false);
                    _pools[i].Add(spawned);
                }
            }
        }

        private bool TryGetObject(out Enemy result)
        {
            int randomEnemyPool = Random.Range(0, _enemyEnabler.EnemiesAvaliable);
            int randomEnemy = Random.Range(0, _pools[randomEnemyPool].Count);
            result = _pools[randomEnemyPool][randomEnemy];
            return result.gameObject.activeSelf == false;
        }

        private void SetEnemy(Enemy enemy, Vector3 spawnPoint)
        {
            enemy.gameObject.SetActive(true);
            enemy.transform.position = spawnPoint;
            enemy.SetAliveContainer(_activeEnemyPool);
        }
    }
}

