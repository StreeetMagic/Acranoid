using UnityEngine;
using Enemy;

public class ActiveEnemyPool : MonoBehaviour
{
    public event System.Action<Enemy.Enemy> EnemyDied;

    public void GetEnemyTransform(Enemy.Enemy enemy)
    {
        EnemyDied?.Invoke(enemy);
    }}
