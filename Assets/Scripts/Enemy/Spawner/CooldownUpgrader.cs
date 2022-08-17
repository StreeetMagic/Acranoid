using UnityEngine;

namespace Scripts.Enemy.Spawner
{
    public class CooldownUpgrader : MonoBehaviour
    {
        [field: SerializeField] private float StartMultiplier { get; set; } = 10f;
        [field: SerializeField] private float CoolodownDelta { get; set; } = .2f;
        [field: SerializeField] private float MaxMultiplier { get; set; } = .5f;
        [field: SerializeField] private float MultiplierCooldown { get; set; } = 5;

        public float CurrentSpawnCooldown
        {
            get
            {
                var stage = (int)(Time.realtimeSinceStartup / MultiplierCooldown);
                var currentMultiplier = StartMultiplier - CoolodownDelta * stage;

                if (currentMultiplier > MaxMultiplier)
                    return currentMultiplier;

                return MaxMultiplier;
            }
        }
    }
}