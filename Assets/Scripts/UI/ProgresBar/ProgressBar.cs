using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    [SerializeField] private float _speedOfChange;
    [SerializeField] private Slider _slider;
    [SerializeField] private UIRequireComponents _UIRequireComponents;

    private Coroutine _changeValue;    
    private int _unloadBlocks;
    private int _allBlocks;
    private float _currentValue;    

    public event UnityAction <bool, bool, bool > IsChangedValue;

    private void Start()
    {
        if (_speedOfChange == 0 || _slider == null || _UIRequireComponents == null)
        {
            Debug.Log("No serializefiel in " + gameObject.name);
        }
    }

    private void OnEnable()
    {
        _slider.value = 0;

        _UIRequireComponents.CalculatorBlocks.IsChangedNumberUnloadBlocks += OnChangedNumberBlocks;
    }

    private void OnDisable()
    {
        _UIRequireComponents.CalculatorBlocks.IsChangedNumberUnloadBlocks -= OnChangedNumberBlocks;
    }

    private void OnChangedNumberBlocks(int unloadBlocks)
    {
        if (_allBlocks == 0)
        {
            _allBlocks = _UIRequireComponents.CalculatorBlocks.AllBlocks;
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

            if (_slider.value > (float) _UIRequireComponents.EndelLevel.MinProcent / 100 & _slider.value < (float)_UIRequireComponents.EndelLevel.MiddleProcent / 100)
            {
                IsChangedValue?.Invoke(true, false, false);
            }

            if (_slider.value > (float)_UIRequireComponents.EndelLevel.MiddleProcent / 100 & _slider.value < (float)_UIRequireComponents.EndelLevel.MaxProcent / 100)
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