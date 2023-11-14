using System.Collections;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(RectTransform))]
[RequireComponent(typeof(Image))]

public class InventoryBarIconFlash : MonoBehaviour
{
    [SerializeField] private float _deltaScale;
    [SerializeField] private float _duration;
    [SerializeField] private Color _targetColor;
    [SerializeField] private RectTransform _rectTransform;
    [SerializeField] private Image _image;
    [SerializeField] private UIRequireComponents _UIRequireComponents;

    private Coroutine _flash;
    private Vector3 _startScale;
    private Vector3 _currentScale;
    private Vector3 _targetScale;
    private Color _startColor;
    private float _deltaScaleCalculated;
    private int _currentCountOfBlocks;
    private int _maxCountOfBlocks;

    private void Start()
    {
        if (_deltaScale == 0 || _duration == 0 || _targetColor == null || _rectTransform == null || _image == null || _UIRequireComponents == null)
        {
            Debug.Log("No serializefiel in " + gameObject.name);
        }
    }

    private void OnEnable()
    {
        _startColor = _image.color;

        _startScale = _rectTransform.localScale;
        _currentScale = _startScale;
        _targetScale = new Vector3(_startScale.x + _deltaScale, _startScale.y + _deltaScale, _startScale.z);

        _deltaScaleCalculated = _deltaScale / (_duration / 2 / Time.deltaTime);

        _UIRequireComponents.Inventory.IsChangedNumberBlocks += OnChangedNumberBlocksInInventory;
    }

    private void OnDisable()
    {
        _UIRequireComponents.Inventory.IsChangedNumberBlocks -= OnChangedNumberBlocksInInventory;
    }

    private void OnChangedNumberBlocksInInventory(int current, int max)
    {
        _currentCountOfBlocks = current;
        _maxCountOfBlocks = max;

        if (current == max)
        {
            StartFlash();
        }
    }

    private IEnumerator Flash()
    {
        bool isBack = false;

        while (true)
        {
            if (_currentScale.x == _targetScale.x & isBack == false)
                isBack = true;

            if (_currentScale.x == _startScale.x & isBack == true)
                isBack = false;

            if (_currentScale.x < _targetScale.x & isBack == false)
            {
                SetColor(_targetColor);
                SetScale(_targetScale);
            }

            if (_currentScale.x > _startScale.x & isBack == true)
            {
                SetColor(_startColor);
                SetScale(_startScale);
            }

            if (_currentCountOfBlocks != _maxCountOfBlocks & isBack == true)
            {
                SetColor(_startColor);
                SetScale(_startScale);

                StopFlash();
            }

            _rectTransform.localScale = _currentScale;

            yield return null;
        }
    }

    private void SetColor(Color color)
    {
        _image.CrossFadeColor(color, _duration / 2, false, false);
    }

    private void SetScale(Vector3 target)
    {
        _currentScale.x = Mathf.MoveTowards(_currentScale.x, target.x, _deltaScaleCalculated);
        _currentScale.y = Mathf.MoveTowards(_currentScale.y, target.y, _deltaScaleCalculated);
        _currentScale.z = Mathf.MoveTowards(_currentScale.z, target.z, _deltaScaleCalculated);
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
        if (_flash!=null)
        {
            StopCoroutine(_flash);
            _flash = null;
        }
    }
}