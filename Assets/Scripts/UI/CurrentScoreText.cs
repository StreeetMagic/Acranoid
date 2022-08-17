using TMPro;
using UnityEngine;

namespace Scripts.UI
{
    public class CurrentScoreText : MonoBehaviour
    {
        [SerializeField] private Player.Player _player;
        [SerializeField] private TextMeshProUGUI _text;

        private void OnEnable()
        {
            OnScoreChanged(0);
            _player.ScoreChanged += OnScoreChanged;
        }

        private void OnDisable()
        {
            _player.ScoreChanged -= OnScoreChanged;
        }

        private void OnScoreChanged(float score)
        {
            var text = "Score:" + _player.Score;
            _text.text = text;
        }
    }
}