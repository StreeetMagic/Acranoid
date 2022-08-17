using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts.Enemy.Spawner
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

        private readonly List<List<Enemy>> _pools = new List<List<Enemy>>();

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
            var gameIsOn = true;

            while (gameIsOn)
            {
                if (TryGetObject(out var enemy))
                {
                    ElapsedTime = 0;
                    var spawnPointNumber = Random.Range(0, _spawnPoints.Length);
                    SetEnemy(enemy, _spawnPoints[spawnPointNumber].position);
                }

                yield return new WaitForSeconds(_cooldownUpgrader.CurrentSpawnCooldown);
            }
        }

        private void FillPools()
        {
            for (var i = 0; i < _enemies.Length; i++) _pools.Add(new List<Enemy>());
        }

        private void Initialize()
        {
            for (var i = 0; i < _enemies.Length; i++)
            for (var j = 0; j < _enemies[i].MaxCount; j++)
            {
                var spawned = Instantiate(_enemies[i], _inactiveEnemyPool.transform);
                spawned.SetActiveBulletPool(_activeBulletPool);
                spawned.gameObject.SetActive(false);
                _pools[i].Add(spawned);
            }
        }

        private bool TryGetObject(out Enemy result)
        {
            var randomEnemyPool = Random.Range(0, _enemyEnabler.EnemiesAvaliable);
            var randomEnemy = Random.Range(0, _pools[randomEnemyPool].Count);
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