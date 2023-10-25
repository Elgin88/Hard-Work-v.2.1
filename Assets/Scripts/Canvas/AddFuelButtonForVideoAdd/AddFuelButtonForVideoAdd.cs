using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]

public class AddFuelButtonForVideoAdd : MonoBehaviour
{
    private PlayerFuelController _playerFuelController;
    private VideoAdController _videoAdController;
    private RectTransform _rectTransform;
    private PauserGame _pauserGame;
    private Coroutine _flash;
    private Button _addFuelButton;

    private float _deltaRangeInProcent = 30;
    private float _timeOfFlashInSeconds = 0.3f;

    private Vector3 _startScale;
    private Vector3 _currentScale;
    private Vector3 _targetScale;

    private float _deltaSclale => (_targetScale.x - _startScale.x) / (_timeOfFlashInSeconds / Time.deltaTime);

    private void OnEnable()
    {
        _playerFuelController = FindObjectOfType<PlayerFuelController>();
        _videoAdController = FindObjectOfType<VideoAdController>();
        _pauserGame = FindObjectOfType<PauserGame>();

        _addFuelButton = GetComponent<Button>();
        _rectTransform = GetComponent<RectTransform>();       

        _addFuelButton.onClick.AddListener(OnAddFuelButtonClick);        

        _startScale = _rectTransform.localScale;
        _currentScale = _startScale;
        _targetScale = _startScale + _startScale * _deltaRangeInProcent / 100;

        StartFlash();
    }

    private void OnDisable()
    {
        _addFuelButton.onClick.RemoveListener(OnAddFuelButtonClick);

        StopFlash();
    }

    private void OnAddFuelButtonClick()
    {
        _playerFuelController.SetMaxFuel();
        gameObject.SetActive(false);
    }

    private IEnumerator Flash()
    {
        bool isForward = true;

        while (true)
        {
            if (isForward)
            {
                _currentScale.x = Mathf.MoveTowards(_currentScale.x, _targetScale.x, _deltaSclale);
                _currentScale.y = Mathf.MoveTowards(_currentScale.y, _targetScale.y, _deltaSclale);
                _currentScale.z = Mathf.MoveTowards(_currentScale.z, _targetScale.z, _deltaSclale);

                if (_currentScale.x >= _targetScale.x)
                {
                    isForward = false;
                }
            }
            else
            {
                _currentScale.x = Mathf.MoveTowards(_currentScale.x, _startScale.x, _deltaSclale);
                _currentScale.y = Mathf.MoveTowards(_currentScale.y, _startScale.y, _deltaSclale);
                _currentScale.z = Mathf.MoveTowards(_currentScale.z, _startScale.z, _deltaSclale);

                if (_currentScale.x <= _startScale.x)
                {
                    isForward = true;
                }
            }

            _rectTransform.localScale = _currentScale;

            yield return null;
        }
    }

    public void StartFlash()
    {
        if (_flash == null)
        {
            _flash = StartCoroutine(Flash());
        }
    }

    public void StopFlash()
    {
        StopCoroutine(_flash);
        _flash = null;
    }
}