using UnityEngine;

namespace Scripts.Enemy.Sparrow
{
    public class Rotate : MonoBehaviour
    {
        public float RotateSpeed { get; } = .5f;

        private void Update()
        {
            transform.Rotate(0, 0, RotateSpeed);
        }
    }
}