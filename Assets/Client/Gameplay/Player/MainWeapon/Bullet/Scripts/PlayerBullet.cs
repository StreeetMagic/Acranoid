using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public class PlayerBullet : Bullet
    {


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
        private void Update()
        {
            transform.Translate(Vector3.up * Speed * Time.deltaTime);
        }

    }
}

