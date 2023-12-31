using System.Collections;
using HardWork.UI;
using UnityEngine;

namespace HardWork.Education
{
    public class JoystickIndicatorEducation : MonoBehaviour
    {
        [SerializeField] private BarrelIndicatorEducation[] _barrelIndicators;
        [SerializeField] private RequireComponentsForUI _requireComponentsForUI;

        private float _currentPressTime;
        private float _delay = 0.5f;
        private Coroutine _showIndicator;

        private void OnEnable()
        {
            StartShowIndicator();
        }

        private void OnDisable()
        {
            StopShowIndicator();
        }

        private IEnumerator ShowIndicator()
        {
            while (true)
            {
                CalculatePressingTimeOfJoystick();

                if (_currentPressTime > _delay)
                {
                    _currentPressTime = 0;

                    foreach (var indicator in _barrelIndicators)
                    {
                        if (indicator != null)
                        {
                            indicator.gameObject.SetActive(true);
                        }
                    }

                    gameObject.SetActive(false);
                }

                yield return null;
            }
        }

        private void StartShowIndicator()
        {
            if (_showIndicator == null)
            {
                _showIndicator = StartCoroutine(ShowIndicator());
            }
        }

        private void StopShowIndicator()
        {
            if (_showIndicator != null)
            {
                StopCoroutine(_showIndicator);
                _showIndicator = null;
            }
        }

        private void CalculatePressingTimeOfJoystick()
        {
            if (_requireComponentsForUI.PlayerSpeedSetter.CurrentSpeed > 1)
            {
                _currentPressTime += Time.deltaTime;
            }
            else
            {
                _currentPressTime = 0;
            }
        }
    }
}