using Scripts.MainWeapon.Bullet;
using UnityEngine;

namespace Scripts.Player
{
    public class PlayerBullet : Bullet
    {
        private void Update()
        {
            transform.Translate(Vector3.up * Speed * Time.deltaTime);
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.TryGetComponent(out Enemy.Enemy enemy))
            {
                enemy.TakeDamage(Damage);
                gameObject.SetActive(false);
            }

            if (collision.TryGetComponent(out Bullet bullet))
            {
                gameObject.SetActive(false);
                bullet.gameObject.SetActive(false);
            }
        }
    }
}