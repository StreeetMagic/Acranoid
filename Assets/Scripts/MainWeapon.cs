using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainWeapon : MonoBehaviour
{
    [SerializeField] private Transform[] _barrels;
    [SerializeField] private Bullet _bullet;
    [SerializeField] private Transform _BulletContainer;
    [SerializeField] private Transform _activeBulletPool;
    [SerializeField] private List<Bullet> _pool = new List<Bullet>();

    private Coroutine _shooting;

    [field: SerializeField] protected float BulletsPerSecond { get; private set; } = 1;
    [field: SerializeField] private int Capacity { get; set; }
    [field: SerializeField] private bool IsShooting { get; set; } = true;

    private void OnEnable()
    {
        Initialize();
        _shooting = StartCoroutine(Shooting());
    }

    private void Initialize()
    {
        for (int i = 0; i < Capacity; i++)
        {
            Bullet spawned = Instantiate(_bullet, _BulletContainer);
            spawned.gameObject.SetActive(false);
            _pool.Add(spawned);
        }
    }

    private void FireBullet(Bullet bullet, Transform shootingPoint)
    {
        bullet.gameObject.SetActive(true);
        bullet.transform.SetPositionAndRotation(shootingPoint.position, shootingPoint.rotation);
        bullet.transform.SetParent(_activeBulletPool);
    }

    private IEnumerator Shooting()
    {
        float cooldown = 1 / BulletsPerSecond;
        bool isShooted;

        WaitForSeconds reloading = new WaitForSeconds(cooldown);
        yield return reloading;

        while (IsShooting)
        {
            if (_BulletContainer.transform.childCount < _barrels.Length)
            {
                yield return reloading;
            }
            else
            {
                for (int i = 0; i < _barrels.Length; i++)
                {
                    isShooted = false;

                    if (_barrels[i].gameObject.activeSelf)
                    {
                        while (isShooted == false)
                        {
                            if (TryGetObject(out Bullet bullet))
                            {
                                FireBullet(bullet, _barrels[i]);
                                isShooted = true;
                            }
                        }
                    }
                }
                yield return reloading;
            }
        }
    }

    protected bool TryGetObject(out Bullet result)
    {
        result = _pool[Random.Range(0, _pool.Count)];
        return result.gameObject.activeSelf == false ? result != null : result == null;
    }

    protected void SetBarrelStatus(int number, bool status)
    {
        _barrels[number].gameObject.SetActive(status);
    }

    protected void SetFireRate(float fireRate)
    {
        BulletsPerSecond = fireRate;

        if (_shooting != null)
        {
            StopCoroutine(_shooting);
        }
        _shooting = StartCoroutine(Shooting());
    }

    public void SetActiveBulletPool(Transform pool)
    {
        _activeBulletPool = pool;
    }
}


