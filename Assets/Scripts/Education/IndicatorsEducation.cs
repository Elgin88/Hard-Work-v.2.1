using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IndicatorsEducation : MonoBehaviour
{
    [SerializeField] private BarrelIndicatorEducation[] _barrelIndicatorsEducation;
    [SerializeField] private CollectorIndicatorEducation[] _collectorIndicatorsEducation;
    [SerializeField] private GarageIndicatorEducation[] _garageIndicatorsEducation;
    [SerializeField] private JoystickIndicatorEducation[] _joystickIndicatorEducation;

    public BarrelIndicatorEducation[] BarrelIndicators => _barrelIndicatorsEducation;
    public CollectorIndicatorEducation[] CollectorIndicatorsEducation => _collectorIndicatorsEducation;
    public GarageIndicatorEducation[] GarageIndicatorsEducation => _garageIndicatorsEducation;

    private void Start()
    {
        foreach (var item in _joystickIndicatorEducation)
        {
            item.gameObject.SetActive(true);
        }
    }
}