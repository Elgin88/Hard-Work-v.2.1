using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class FuelBarIndicateFuelLess : MonoBehaviour
{
    [SerializeField] private float _minLevelForIndicate;
    [SerializeField] private float _duration;
    [SerializeField] private float _deltaScale;
    [SerializeField] private Color _targetColor;
    [SerializeField] private UIRequireComponents _UIRequireComponents;
    [SerializeField] private RectTransform _rectTransform;
    [SerializeField] private Image _image;

    private Coroutine _flash;
    private Vector3 _startStale;
    private Vector3 _currentScale;
    private Vector3 _targetScale;
    private Color _startColor;
    private float _currentFuel;
    private float _maxFuel;
    private float _deltaScaleCalculated;

    private void OnEnable()
    {
        if (_minLevelForIndicate==0 || _duration == 0 ||
            _deltaScale == 0 || _targetColor == null ||
            _UIRequireComponents == null || _rectTransform == null ||
            _image == null)
        {
            Debug.Log("No SerializeField in " + gameObject.name);
        }

        _startStale = _rectTransform.localScale;
        _startColor = _image.color;
        _currentScale = _startStale;

        _targetScale.x = _startStale.x + _deltaScale;
        _targetScale.y = _startStale.y + _deltaScale;
        _targetScale.z = _startStale.z + _deltaScale;

        _deltaScaleCalculated = _deltaScale / (_duration / 2 / Time.deltaTime);
        _UIRequireComponents.PlayerFuelController.IsFuelChanged += OnFuelChanged;
    } 

    private void OnDisable()
    {
        _UIRequireComponents.PlayerFuelController.IsFuelChanged -= OnFuelChanged;
    }

    private void OnFuelChanged(float current, float max)
    {
        _currentFuel = current;
        _maxFuel = max;

        if (_currentFuel / _maxFuel < _minLevelForIndicate)
        {
            StartFlash();
        }
    }

    private IEnumerator Flash()
    {
        bool isBack = false;

        while (true)
        {
            if (_currentScale.x < _targetScale.x & isBack == false)
            {
                SetScale(_targetScale);
                SetColor(_targetColor);
            }
            else
            {
                isBack = true;
            }

            if (_currentScale.x > _startStale.x & isBack == true)
            {
                SetScale(_startStale);
                SetColor(_startColor);
            }
            else
            {
                isBack = false;
            }

            if (_currentFuel/_maxFuel > _minLevelForIndicate)
            {
                SetScale(_startStale);
                SetColor(_startColor);

                StopCoroutine(_flash);
            }

            _rectTransform.localScale = _currentScale;

            yield return null;
        }
    }

    private void SetScale(Vector3 scale)
    {
        _currentScale.x = Mathf.MoveTowards(_currentScale.x, scale.x, _deltaScaleCalculated);
        _currentScale.y = Mathf.MoveTowards(_currentScale.y, scale.y, _deltaScaleCalculated);
        _currentScale.z = Mathf.MoveTowards(_currentScale.z, scale.z, _deltaScaleCalculated);
    }

    private void SetColor(Color color)
    {
        _image.CrossFadeColor(color, _duration / 2, false, false);
    }

    private void StartFlash()
    {
        if (_flash == null)
        {
            _flash = StartCoroutine(Flash());
        }
    }

    private void StopFlash()
    {
        if (_flash != null)
        {
            StopCoroutine(_flash);
            _flash = null;
        }
    }
}