using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using HardWork;

namespace HardWork
{
    public class ProgressBar : MonoBehaviour
    {
        [SerializeField] private float _speedOfChange;
        [SerializeField] private Slider _slider;
        [SerializeField] private RequireComponentsForUI _requireComponentsForUI;

        private Coroutine _changeValue;
        private int _unloadBlocks;
        private int _allBlocks;
        private float _currentValue;

        public Action <bool, bool, bool> IsChangedValue;

        private void OnEnable()
        {
            _slider.value = 0;

            _requireComponentsForUI.CalculatorBlocks.NumberUnloadBlocksIsChanged += OnChangedNumberBlocks;
        }

        private void OnDisable()
        {
            _requireComponentsForUI.CalculatorBlocks.NumberUnloadBlocksIsChanged -= OnChangedNumberBlocks;
        }

        private void OnChangedNumberBlocks(int unloadBlocks)
        {
            if (_allBlocks == 0)
            {
                _allBlocks = _requireComponentsForUI.CalculatorBlocks.AllBlocks;
            }

            _unloadBlocks = unloadBlocks;

            StartChangeValue();
        }

        private IEnumerator ChangeValue()
        {
            while (true)
            {
                _currentValue = _slider.value;
                _slider.value = Mathf.MoveTowards(_currentValue, (float)_unloadBlocks / _allBlocks, _speedOfChange * Time.deltaTime);

                if (_slider.value > (float)_requireComponentsForUI.LevelCompleter.MinProcent / 100 & _slider.value < (float)_requireComponentsForUI.LevelCompleter.MiddleProcent / 100)
                {
                    IsChangedValue?.Invoke(true, false, false);
                }

                if (_slider.value > (float)_requireComponentsForUI.LevelCompleter.MiddleProcent / 100 & _slider.value < (float)_requireComponentsForUI.LevelCompleter.MaxProcent / 100)
                {
                    IsChangedValue?.Invoke(true, true, false);
                }

                if (_slider.value == 1)
                {
                    IsChangedValue?.Invoke(true, true, true);
                }

                yield return null;
            }
        }

        private void StartChangeValue()
        {
            if (_changeValue == null)
            {
                _changeValue = StartCoroutine(ChangeValue());
            }
        }

        private void StopChangeValue()
        {
            if (_changeValue != null)
            {
                StopCoroutine(_changeValue);
                _changeValue = null;
            }
        }
    }
}