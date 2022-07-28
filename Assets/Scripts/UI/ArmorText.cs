using TMPro;
using UnityEngine;

public class ArmorText : MonoBehaviour
{
    [SerializeField] private Player.Player _player;
    [SerializeField] private TextMeshProUGUI _armor;
         
    private void OnEnable()
    {
        _player.ArmorChanged += OnArmorChanged;
        _armor.text = _player.Armor.ToString();
    }

    private void OnDisable()
    {
        _player.ArmorChanged -= OnArmorChanged;
    }

    private void OnArmorChanged(float value)
    {
        string text = value.ToString();
        _armor.text = text;
    }
}
