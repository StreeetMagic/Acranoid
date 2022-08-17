using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace Scripts.Enemy.UI
{
    public class HealthBar : MonoBehaviour
    {
        [SerializeField] private Slider _slider;
        [SerializeField] private Enemy _enemy;

        private Coroutine _coroutine;

        [field: SerializeField] public float RecoveryRate { get; private set; } = 50;

        private void OnEnable()
        {
            _slider.value = 1;
            _enemy.HealthChanged += OnHealthChanged;
        }

        private void OnDisable()
        {
            _enemy.HealthChanged -= OnHealthChanged;
        }

        private void OnHealthChanged(float value)
        {
            if (_coroutine != null) StopCoroutine(_coroutine);
            _coroutine = StartCoroutine(Draw(value));
        }

        private IEnumerator Draw(float value)
        {
            while (_slider.value != value)
            {
                _slider.value = Mathf.MoveTowards(_slider.value, value, Time.deltaTime * RecoveryRate);

                yield return null;
            }
        }
    }
}