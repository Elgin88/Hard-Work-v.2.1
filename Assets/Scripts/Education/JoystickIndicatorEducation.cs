using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(RectTransform))]

public class JoystickIndicatorEducation : MonoBehaviour
{
    [SerializeField] private BarrelIndicatorEducation[] _barrelIndicators;
    [SerializeField] private FixedJoystick _fixedJoystick;
    [SerializeField] private CanvasUI _canvasUI;

    private string _levelName = "Level1";

    private Scene _currentScene;
    private float _currentPressTime;
    private float _delay = 1;

    private Vector3 _startScale;
    private Vector3 _currentScale;
    private Vector3 _targetScale;
    private bool _isNeedBarrelsIndicators = true;
    private Coroutine _showIndicator;

    private void Start()
    {
        _currentScene = SceneManager.GetActiveScene();

        if (_currentScene.name != _levelName)
        {
            Destroy(gameObject);
            return;
        }
    }

    private void OnEnable()
    {
        StartShowIndicator();
    }

    private void OnDisable()
    {
        StopShowIndicator();
    }

    private  IEnumerator ShowIndicator()
    {
        while (true)
        {
            CalculatePressingTimeOfJoystick();

            if (_currentPressTime > _delay)
            {
                _currentPressTime = 0;

                foreach (var indicator in _barrelIndicators)
                {
                    if (indicator!=null)
                    {
                        indicator?.gameObject.SetActive(true);
                    }                    
                }

                StopShowIndicator();

                gameObject.SetActive(false);
            }

            yield return null;
        }        
    }

    private void StartShowIndicator()
    {
        if (_showIndicator==null)
        {
            _showIndicator = StartCoroutine(ShowIndicator());
        }
    }

    private void StopShowIndicator()
    {
        if (_showIndicator !=null)
        {
            StopCoroutine(_showIndicator);
            _showIndicator = null;
        }
    }


    private void CalculatePressingTimeOfJoystick()
    {
        if (_canvasUI.PlayerSpeedSetter.CurrentSpeed > 1)
        {
            _currentPressTime += Time.deltaTime;
        }
        else
        {
            _currentPressTime = 0;
        }
    }
}