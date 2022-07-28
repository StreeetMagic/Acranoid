using UnityEngine;

namespace Enemy
{
    public class Rotate : MonoBehaviour
    {
        public float RotateSpeed { get; private set; } = .5f;
        
        private void Update()
        {
            transform.Rotate(0, 0, RotateSpeed);
        }
    }
}
