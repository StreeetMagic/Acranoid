using System.Globalization;
using TMPro;
using UnityEngine;

namespace Scripts.UI
{
    public class ArmorText : MonoBehaviour
    {
        [SerializeField] private Player.Player _player;
        [SerializeField] private TextMeshProUGUI _armor;

        private void OnEnable()
        {
            _player.ArmorChanged += OnArmorChanged;
            _armor.text = _player.Armor.ToString(CultureInfo.InvariantCulture);
        }

        private void OnDisable()
        {
            _player.ArmorChanged -= OnArmorChanged;
        }

        private void OnArmorChanged(float value)
        {
            var text = value.ToString(CultureInfo.InvariantCulture);
            _armor.text = text;
        }
    }
}