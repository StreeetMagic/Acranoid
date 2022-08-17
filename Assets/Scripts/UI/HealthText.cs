using System.Globalization;
using TMPro;
using UnityEngine;

namespace Scripts.UI
{
    public class HealthText : MonoBehaviour
    {
        [SerializeField] private Player.Player _player;
        [SerializeField] private TextMeshProUGUI _health;

        private void OnEnable()
        {
            _player.HealthChanged += OnHealthChanged;
            _health.text = _player.Health.ToString(CultureInfo.InvariantCulture);
        }

        private void OnDisable()
        {
            _player.HealthChanged -= OnHealthChanged;
        }

        private void OnHealthChanged(float value)
        {
            var text = value.ToString(CultureInfo.InvariantCulture);
            _health.text = text;
        }
    }
}