using TMPro;
using UnityEngine;

public class HealthText : MonoBehaviour
{
    [SerializeField] private Player.Player _player;
    [SerializeField] private TextMeshProUGUI _health;
         
    private void OnEnable()
    {
        _player.HealthChanged += OnHealthChanged;
        _health.text = _player.Health.ToString();
    }

    private void OnDisable()
    {
        _player.HealthChanged -= OnHealthChanged;
    }

    private void OnHealthChanged(float value)
    {
        string text = value.ToString();
        _health.text = text;
    }
}
