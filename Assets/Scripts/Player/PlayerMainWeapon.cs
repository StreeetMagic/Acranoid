using UnityEngine;

public class PlayerMainWeapon : MainWeapon
{
    [SerializeField] private int _level;
    private int _startLevel = 1;
    private int _maxLevel = 5;

    private float _startBulletsPerSecond = 7;
    private float _maxBulletsPerSecond = 9;
    private float _bulletsPerSecondIncrease = 1f;

    private void Start()
    {
        _level = _startLevel;
        SetFireRate(_startBulletsPerSecond);
        SetLevel1();
    }

    private void EnableBarrelsByLevel(int level)
    {
        switch (level)
        {
            case 1:
                SetLevel1();
                break;
            case 2:
                SetLevel2();
                break;
            case 3:
                SetLevel3();
                break;
            case 4:
                SetLevel4();
                break;
            case 5:
                SetLevel5();
                break;
        }
    }

    public void Upgrade()
    {
        if (BulletsPerSecond < _maxBulletsPerSecond)
        {
            SetFireRate(BulletsPerSecond + _bulletsPerSecondIncrease);
        }
        else if (_level < _maxLevel)
        {
            _level++;
            EnableBarrelsByLevel(_level);
            SetFireRate(_startBulletsPerSecond);
        }
    }

    private void SetLevel1()
    {
        SetBarrelStatus(0, false);
        SetBarrelStatus(1, false);
        SetBarrelStatus(2, true);
        SetBarrelStatus(3, false);
        SetBarrelStatus(4, false);
    }

    private void SetLevel2()
    {
        SetBarrelStatus(0, false);
        SetBarrelStatus(1, true);
        SetBarrelStatus(2, false);
        SetBarrelStatus(3, true);
        SetBarrelStatus(4, false);
    }

    private void SetLevel3()
    {
        SetBarrelStatus(0, false);
        SetBarrelStatus(1, true);
        SetBarrelStatus(2, true);
        SetBarrelStatus(3, true);
        SetBarrelStatus(4, false);
    }

    private void SetLevel4()
    {
        SetBarrelStatus(0, true);
        SetBarrelStatus(1, true);
        SetBarrelStatus(2, false);
        SetBarrelStatus(3, true);
        SetBarrelStatus(4, true);
    }

    private void SetLevel5()
    {
        SetBarrelStatus(0, true);
        SetBarrelStatus(1, true);
        SetBarrelStatus(2, true);
        SetBarrelStatus(3, true);
        SetBarrelStatus(4, true);
    }
}
