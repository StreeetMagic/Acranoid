using System.Collections.Generic;
using Scripts.Enemy.Spawner;
using UnityEngine;

namespace Scripts.Buff
{
    public class Spawner : MonoBehaviour
    {
        [SerializeField] private Buff[] _buffs;
        [SerializeField] private GameObject _container;
        [SerializeField] private Transform _activeBuffPool;
        [SerializeField] private ActiveEnemyPool _activeEnemyPool;

        private readonly List<List<Buff>> _pools = new List<List<Buff>>();

        [field: SerializeField] public int Capacity { get; private set; }

        private void Start()
        {
            FillPools();
            Initialize();
        }

        private void OnEnable()
        {
            _activeEnemyPool.EnemyDied += SpawnBuff;
        }

        private void OnDisable()
        {
            _activeEnemyPool.EnemyDied -= SpawnBuff;
        }

        private void FillPools()
        {
            for (var i = 0; i < _buffs.Length; i++) _pools.Add(new List<Buff>());
        }

        private void Initialize()
        {
            for (var i = 0; i < _buffs.Length; i++)
            for (var j = 0; j < Capacity; j++)
            {
                var spawned = Instantiate(_buffs[i], _container.transform);
                spawned.gameObject.SetActive(false);
                _pools[i].Add(spawned);
            }
        }

        private bool TryGetObject(out Buff result)
        {
            var randomEnemyPool = Random.Range(0, _buffs.Length);
            var randomEnemy = Random.Range(0, Capacity);
            result = _pools[randomEnemyPool][randomEnemy];

            return result.gameObject.activeSelf == false;
        }

        private void SpawnBuff(Enemy.Enemy enemy)
        {
            if (!TryGetObject(out var buff)) return;
            buff.gameObject.SetActive(true);
            buff.transform.position = enemy.transform.position;
            buff.SetActiveContainer(_activeBuffPool);
        }
    }
}