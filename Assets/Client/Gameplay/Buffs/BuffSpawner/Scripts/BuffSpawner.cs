using System.Collections.Generic;
using UnityEngine;

public class BuffSpawner : MonoBehaviour
{
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private Buff[] _buffs;
    [SerializeField] private GameObject _container;
    [SerializeField] private Transform _ActiveBuffPool;
    [SerializeField] private ActiveEnemyPool _activeEnemyPool;

    private List<List<Buff>> _pools = new List<List<Buff>>();
    
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
        for (int i = 0; i < _buffs.Length; i++)
        {
            _pools.Add(new List<Buff>());
        }
    }

    protected void Initialize()
    {
        for (int i = 0; i < _buffs.Length; i++)
        {
            for (int j = 0; j < Capacity; j++)
            {
                Buff spawned = Instantiate(_buffs[i], _container.transform);
                spawned.gameObject.SetActive(false);
                _pools[i].Add(spawned);
            }
        }
    }

    private bool TryGetObject(out Buff result)
    {
        int randomEnemyPool = Random.Range(0, _buffs.Length);
        int randomEnemy = Random.Range(0, Capacity);
        result = _pools[randomEnemyPool][randomEnemy];
        return result.gameObject.activeSelf == false;
    }

    private void SpawnBuff(Enemy.Enemy enemy)
    {
        if (TryGetObject(out Buff buff))
        {
            buff.gameObject.SetActive(true);
            buff.transform.position = enemy.transform.position;
            buff.SetActiveContainer(_ActiveBuffPool);
        }
    }
}

