using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Enemy
{
    public class MoveSpeedUpgrader : MonoBehaviour
    {
        [field: Header("Move speed multiplier settings:")]
        [field: SerializeField] private float StartMultiplier { get; set; } = .1f;
        [field: SerializeField] private float Delta { get; set; } = .1f;
        [field: SerializeField] private float MaxMultiplier { get; set; } = 2f;
        [field: SerializeField] private float MultiplierCooldown { get; set; } = 30;

        public float CurrentMultilier
        {
            get
            {
                int stage = (int)(Time.realtimeSinceStartup / MultiplierCooldown);
                float currentMultiplier = StartMultiplier + (Delta * stage);

                if (currentMultiplier < MaxMultiplier)
                {
                    return currentMultiplier;
                }
                else
                {
                    return MaxMultiplier;
                }
            }
        }
    }
}

