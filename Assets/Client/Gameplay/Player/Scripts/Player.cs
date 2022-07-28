using System;
using UnityEngine;
using UnityEngine.Events;

namespace Player
{
    public class Player : MonoBehaviour
    {
        public event Action <float> HealthChanged;
        public event Action <float> ArmorChanged;
        public event Action <float> ScoreChanged;

        [SerializeField] private PlayerMainWeapon _mainWeapon;
        [SerializeField] private ActiveEnemyPool _activeEnemyPool;

        [field: SerializeField] public float StartingHealth { get; private set; } = 5;
        [field: SerializeField] public float StartingArmor { get; private set; } = 10;
        [field: SerializeField] public float Health { get; private set; } = 5;
        [field: SerializeField] public float Armor { get; private set; } = 5;
        [field: SerializeField] public float Score { get; private set; } = 0;

        private void OnEnable()
        {
            _activeEnemyPool.EnemyDied += OnEnemyDied;
        }

        private void OnDisable()
        {
            _activeEnemyPool.EnemyDied -= OnEnemyDied;
        }

        private void Awake()
        {
            Health = StartingHealth;
            Armor = StartingArmor;
        }

        public void TakeDamage(float damage)
        {
            if (Armor >= 1)
            {
                Armor -= damage;

                if (Armor < 0)
                {
                    Armor = 0;
                }
                ArmorChanged?.Invoke(Armor);
            }
            else
            {
                Health--;

                if (Health <= 0)
                {
                    Health = 0;
                    Die();
                }
                HealthChanged?.Invoke(Health);
            }
        }

        public void GainArmor()
        {
            Armor++;
            ArmorChanged?.Invoke(Armor);
        }

        public void GainHealth()
        {
            float maxHealth = StartingHealth;
            
            if (Health < maxHealth)
            {
                Health++;
                HealthChanged?.Invoke(Health);
            }
            else
            {
                Armor++;
                ArmorChanged?.Invoke(Armor);
            }
        }

        private void Die()
        {
            gameObject.SetActive(false);
        }

        public void UpgradeMainWeapon()
        {
            _mainWeapon.Upgrade();
        }

        private void OnEnemyDied(Enemy.Enemy enemy)
        {
            Score += enemy.MaxHealth;
            ScoreChanged?.Invoke(Score);
        }

        public void GainScore(float score)
        {
            Score += score;
            ScoreChanged?.Invoke(Score);
        }
    }
}

