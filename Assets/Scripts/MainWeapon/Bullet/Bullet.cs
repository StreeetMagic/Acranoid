using UnityEngine;

namespace Scripts.MainWeapon.Bullet
{
    public abstract class Bullet : MonoBehaviour
    {
        private GameObject _parent;

        [field: SerializeField] public float Speed { get; protected set; } = 15;
        [field: SerializeField] public int Damage { get; protected set; } = 1;

        private void Awake()
        {
            _parent = transform.parent.gameObject;
        }

        private void OnDisable()
        {
            Invoke(nameof(ReAttachParent), .001f);
        }

        private void ReAttachParent()
        {
            transform.SetParent(_parent.transform);
        }
    }
}