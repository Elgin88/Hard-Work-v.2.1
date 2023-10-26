using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]

public class FuelBar : MonoBehaviour
{
    [SerializeField] private float _speedOfChange;
    [SerializeField] private TMP_Text _max;
    [SerializeField] TMP_Text _middle;
    [SerializeField] TMP_Text _min;
    [SerializeField] private Slider _slider;
    [SerializeField] private CanvasUI _canvasUI;

    private Coroutine _changeSliderValue;
    private float _currentValue;
    private float _targetFuel;
    private float _maxFuel;

    private void OnEnable()
    {
        _slider = GetComponent<Slider>();

        _slider.value = 0;
        _canvasUI.PlayerFuelController.IsFuelChanged += OnFuelChanged;
    }

    private void OnDisable()
    {
        _canvasUI.PlayerFuelController.IsFuelChanged -= OnFuelChanged;
    }

    private void OnFuelChanged(float target, float max)
    {
        _targetFuel = target;
        _maxFuel = max;

        _max.text = max.ToString();
        _middle.text = (max/2).ToString();
        _min.text = "0";

        StartChangeSliderValue();
    }

    private IEnumerator ChangeSliderValue()
    {
        while (true)
        {
            _currentValue = _slider.value;

            _slider.value = _targetFuel / _maxFuel;

            yield return null;
        }
    }

    private void StartChangeSliderValue()
    {
        if (_changeSliderValue == null)
        {
            _changeSliderValue = StartCoroutine(ChangeSliderValue());
        }
    }

    private void StopChangeSliderValue()
    {
        if (_changeSliderValue != null)
        {
            StopCoroutine(_changeSliderValue);
            _changeSliderValue = null;
        }
    }
}