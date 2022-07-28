using UnityEngine;
using System;

namespace Enemy
{
    [RequireComponent(typeof(Movement))]
    public abstract class Enemy : MonoBehaviour
    {
        public event Action<float> HealthChanged;

        [SerializeField] private MainWeapon _mainWeapon;
        [SerializeField] private Transform _activeBulletPool;
        [SerializeField] private Transform _inactivePool;
        [SerializeField] private Transform _activePool;

        [SerializeField] protected Movement Movement;

        [field: SerializeField] public float MaxHealth { get; protected set; }
        [field: SerializeField] public float CurrentHealth { get; protected set; }
        [field: SerializeField] public int XPosition { get; protected set; }
        [field: SerializeField] public int MaxCount { get; protected set; }


        private void Awake()
        {
            Movement = GetComponent<Movement>();
            CurrentHealth = MaxHealth;
            _inactivePool = transform.parent;
        }

        private void OnEnable()
        {
            _mainWeapon.SetActiveBulletPool(_activeBulletPool);
            _activePool = transform.parent;
            XPosition = GetRandomXposition();
        }

        private void OnDisable()
        {
            Invoke(nameof(ReAttachParent), .001f);
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.TryGetComponent(out Player.Player player))
            {
                player.TakeDamage(CurrentHealth);
                Die();
            }
        }

        public void SetAliveContainer(ActiveEnemyPool parent)
        {
            transform.SetParent(parent.transform);
            _activePool = parent.transform;
        }
        
        private int GetRandomXposition()
        {
            int minX = 2;
            int maxX = 7;
            return UnityEngine.Random.Range(minX, maxX);
        }

        private void ReAttachParent()
        {
            transform.SetParent(_inactivePool);
        }

        private void Die()
        {
            CurrentHealth = MaxHealth;
            _activePool.GetComponent<ActiveEnemyPool>().GetEnemyTransform(this);
            gameObject.SetActive(false);
        }

        public void TakeDamage(float damage)
        {
            CurrentHealth -= damage;
            HealthChanged?.Invoke(CurrentHealth / MaxHealth);

            if (CurrentHealth <= 0)
            {
                Die();
            }
        }
        public void SetActiveBulletPool(Transform pool)
        {
            _activeBulletPool = pool;
        }
    }
}
